using adin_api.DTOs;
using adin_api.iRepository;
using adin_api.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace adin_api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "User,Administrator")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TasksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchTasks([FromQuery] RequestParams requestParams, [FromQuery] string search="")
        {
            var tasks = await _unitOfWork.Tasks.GetAll(requestParams, q =>
                     q.TaskDescription.Contains(search)
                 );
            var result = _mapper.Map<IList<TaskDTO>>(tasks);
            Response.Headers.Add("XItemCount", tasks.TotalItemCount.ToString());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetTask")]
        public async Task<IActionResult> GetTask(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _unitOfWork.Tasks.Get(q =>
                    q.Id == id
                //, new List<string> { "TaskCategories" }
                );
            if (task == null) return NotFound();
            var result = _mapper.Map<TaskWithStepsDTO>(task);

            var steps1 = await _unitOfWork.Steps.GetAll(q =>
                    q.TaskId == id
                );
            var steps = steps1.OrderBy(q => q.StepNumber);
            result.Steps = new List<StepDetailsDTO>();
            foreach (var step in steps)
            {
                var r = new StepDetailsDTO();
                r= _mapper.Map<StepDetailsDTO>(step);
                r.Components= _mapper.Map<IList<ComponentBasicDTO>>(await _unitOfWork.Steps.GetStepComponents(step.Id));
                r.Tools = _mapper.Map<IList<ToolBasicDTO>>(await _unitOfWork.Steps.GetStepTools(step.Id));
                r.SafetyTools = _mapper.Map<IList<SafetyToolBasicDTO>>(await _unitOfWork.Steps.GetStepSafetyTools(step.Id));
                r.Images = _mapper.Map<IList<ImageDTO>>(await _unitOfWork.Steps.GetStepImages(step.Id));
                result.Steps.Add(r);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var task = _mapper.Map<Data.Models.Task>(taskDTO);
            await _unitOfWork.Tasks.Insert(task);

            return CreatedAtRoute("GetTask", new { id = task.Id }, _mapper.Map<TaskDTO>(task));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDTO taskDTO) // TODO maybe CreateTaskDTO to avoid id tamper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _unitOfWork.Tasks.Get(q => q.Id == id);
            if (task == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            task=_mapper.Map<Data.Models.Task>(taskDTO);
            task.Id = id;
            _unitOfWork.Tasks.Update(task);

            return CreatedAtRoute("GetTask", new { id = id }, task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _unitOfWork.Tasks.Get(q => q.Id == id);
            if (task == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            await _unitOfWork.Tasks.Delete(task.Id);

            return Ok();
        }
    }
}

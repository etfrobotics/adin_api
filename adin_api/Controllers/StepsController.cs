using adin_api.Data.Models;
using adin_api.DTOs;
using adin_api.iRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "User,Administrator")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StepsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchSteps([FromQuery] RequestParams requestParams, [FromQuery] string search="")
        {
            var steps = await _unitOfWork.Steps.GetAll(requestParams, q =>
                     q.Instructions.Contains(search)
                 );
            var result = _mapper.Map<IList<StepWithIdDTO>>(steps);
            Response.Headers.Add("XItemCount", steps.TotalItemCount.ToString());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetStep")]
        public async Task<IActionResult> GetStep(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var step = await _unitOfWork.Steps.Get(q =>
                    q.Id == id
                );
            if (step == null) return NotFound();
            var result = _mapper.Map<StepBasicWithTaskDTO>(step);
            result.Task = _mapper.Map<TaskDTO>(await _unitOfWork.Tasks.Get(q => q.Id == result.TaskId));
            result.Components = _mapper.Map<IList<ComponentBasicDTO>>(await _unitOfWork.Steps.GetStepComponents(id));
            result.Tools = _mapper.Map<IList<ToolBasicDTO>>(await _unitOfWork.Steps.GetStepTools(id));
            result.SafetyTools = _mapper.Map<IList<SafetyToolBasicDTO>>(await _unitOfWork.Steps.GetStepSafetyTools(id));
            var im = await _unitOfWork.Steps.GetStepImages(id);
            result.Images = _mapper.Map<IList<ImageDTO>>(im);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStep([FromBody] CreateStepDTO stepDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = _mapper.Map<Step>(stepDTO);
            await _unitOfWork.Steps.Insert(step);

            var id = step.Id;
            var result = _mapper.Map<StepDetailsDTO>(step);
            result.Components = _mapper.Map<IList<ComponentBasicDTO>>(await _unitOfWork.Steps.GetStepComponents(id));
            result.Tools = _mapper.Map<IList<ToolBasicDTO>>(await _unitOfWork.Steps.GetStepTools(id));
            result.SafetyTools = _mapper.Map<IList<SafetyToolBasicDTO>>(await _unitOfWork.Steps.GetStepSafetyTools(id));

            return CreatedAtRoute("GetStep", new { id = step.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStep(int id, [FromBody] CreateStepDTO stepDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            if (step == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            step = _mapper.Map<Step>(stepDTO);
            step.Id = id;
            _unitOfWork.Steps.Update(step);

            return CreatedAtRoute("GetTask", new { id = id }, _mapper.Map<StepDTO>(step));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStep(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var step= await _unitOfWork.Steps.Get(q => q.Id == id);
            if (step == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            await _unitOfWork.Steps.Delete(step.Id);

            return Ok();
        }

        [HttpPost("{id}/[action]")]
        public async Task<IActionResult> AddStepComponent(int id, int componentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            var component = await _unitOfWork.Components.Get(q => q.Id == componentId);
            if (step == null || component==null) return BadRequest();
            var success = await _unitOfWork.Steps.AddStepComponent(id, component);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}/[action]")]
        public async Task<IActionResult> DeleteStepComponent(int id, int componentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            var component = await _unitOfWork.Components.Get(q => q.Id == componentId);
            if (step == null || component == null) return BadRequest();
            var success = await _unitOfWork.Steps.DeleteStepComponent(id, component);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpPost("{id}/[action]")]
        public async Task<IActionResult> AddStepTool(int id, int toolId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            var tool = await _unitOfWork.Tools.Get(q => q.Id == toolId);
            if (step == null || tool == null) return BadRequest();
            var success = await _unitOfWork.Steps.AddStepTool(id, tool);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}/[action]")]
        public async Task<IActionResult> DeleteStepTool(int id, int toolId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            var tool = await _unitOfWork.Tools.Get(q => q.Id == toolId);
            if (step == null || tool == null) return BadRequest();
            var success = await _unitOfWork.Steps.DeleteStepTool(id, tool);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpPost("{id}/[action]")]
        public async Task<IActionResult> AddStepSafetyTool(int id, int safetyToolId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            var safetyTool = await _unitOfWork.SafetyTools.Get(q => q.Id == safetyToolId);
            if (step == null || safetyTool == null) return BadRequest();
            var success = await _unitOfWork.Steps.AddStepSafetyTool(id, safetyTool);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}/[action]")]
        public async Task<IActionResult> DeleteStepSafetyTool(int id, int safetyToolId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            var safetyTool = await _unitOfWork.SafetyTools.Get(q => q.Id == safetyToolId);
            if (step == null || safetyTool == null) return BadRequest();
            var success = await _unitOfWork.Steps.DeleteStepSafetyTool(id, safetyTool);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpPost("{id}/[action]")]
        public async Task<IActionResult> AddStepImage(int id, int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            var image = await _unitOfWork.Images.Get(q => q.Id == imageId);
            if (step == null || image == null) return BadRequest();
            var success = await _unitOfWork.Steps.AddStepImage(id, image);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}/[action]")]
        public async Task<IActionResult> DeleteStepImage(int id, int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var step = await _unitOfWork.Steps.Get(q => q.Id == id);
            var image = await _unitOfWork.Images.Get(q => q.Id == imageId);
            if (step == null || image == null) return BadRequest();
            var success = await _unitOfWork.Steps.DeleteStepImage(id, image);
            if (success) return Ok();
            return BadRequest();
        }
    }
}

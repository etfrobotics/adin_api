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
    public class ToolsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToolsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchTools([FromQuery] RequestParams requestParams, [FromQuery] string search="")
        {
            var tools = await _unitOfWork.Tools.GetAll(requestParams, q =>
                     q.Name.Contains(search)
                 );
            var result = _mapper.Map<IList<ToolBasicDTO>>(tools);
            Response.Headers.Add("XItemCount", tools.TotalItemCount.ToString());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetTool")]
        public async Task<IActionResult> GetTool(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tool = await _unitOfWork.Tools.Get(q =>
                    q.Id == id
                    //, new List<string> { "TaskCategories" }
                );
            if (tool == null) return NotFound();
            var result = _mapper.Map<ToolBasicDTO>(tool);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTool([FromBody] CreateToolDTO toolDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tool = _mapper.Map<Tool>(toolDTO);
            await _unitOfWork.Tools.Insert(tool);

            return CreatedAtRoute("GetTool", new { id = tool.Id }, _mapper.Map<ToolBasicDTO>(tool));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTool(int id, [FromBody] CreateToolDTO toolDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tool = await _unitOfWork.Tools.Get(q => q.Id == id);
            if (tool == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            tool = _mapper.Map<Tool>(toolDTO);
            tool.Id = id;
            _unitOfWork.Tools.Update(tool);

            return CreatedAtRoute("GetTool", new { id = id }, _mapper.Map<ToolBasicDTO>(tool));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTool(int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tool = await _unitOfWork.Tools.Get(q => q.Id == id);
            if (tool == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            await _unitOfWork.Tools.Delete(tool.Id);

            return Ok();
        }
    }
}

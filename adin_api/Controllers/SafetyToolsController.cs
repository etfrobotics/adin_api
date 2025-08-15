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
    public class SafetyToolsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SafetyToolsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchSafetyTools([FromQuery] RequestParams requestParams, [FromQuery] string search="")
        {
            var safetyTools = await _unitOfWork.SafetyTools.GetAll(requestParams, q =>
                     q.Name.Contains(search)
                 );
            var result = _mapper.Map<IList<SafetyToolBasicDTO>>(safetyTools);
            Response.Headers.Add("XItemCount", safetyTools.TotalItemCount.ToString());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetSafetyTool")]
        public async Task<IActionResult> GetSafetyTool(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var safetyTool = await _unitOfWork.SafetyTools.Get(q =>
                    q.Id == id
                    //, new List<string> { "TaskCategories" }
                );
            if (safetyTool == null) return NotFound();
            var result = _mapper.Map<SafetyToolBasicDTO>(safetyTool);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSafetyTool([FromBody] CreateSafetyToolDTO safetyToolDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var safetyTool = _mapper.Map<SafetyTool>(safetyToolDTO);
            await _unitOfWork.SafetyTools.Insert(safetyTool);

            return CreatedAtRoute("GetSafetyTool", new { id = safetyTool.Id }, _mapper.Map<SafetyToolBasicDTO>(safetyTool));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSafetyTool(int id, [FromBody] CreateSafetyToolDTO safetyToolDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var safetyTool = await _unitOfWork.SafetyTools.Get(q => q.Id == id);
            if (safetyTool == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            safetyTool = _mapper.Map<SafetyTool>(safetyToolDTO);
            safetyTool.Id = id;
            _unitOfWork.SafetyTools.Update(safetyTool);

            return CreatedAtRoute("GetSafetyTool", new { id = id }, _mapper.Map<SafetyToolBasicDTO>(safetyTool));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSafetyTool(int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var safetyTool = await _unitOfWork.SafetyTools.Get(q => q.Id == id);
            if (safetyTool == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            await _unitOfWork.SafetyTools.Delete(safetyTool.Id);

            return Ok();
        }
    }
}

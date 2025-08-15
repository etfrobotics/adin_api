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
    public class ComponentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComponentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchComponents([FromQuery] RequestParams requestParams, [FromQuery] string search="")
        {
            var components = await _unitOfWork.Components.GetAll(requestParams, q =>
                     q.Name.Contains(search)
                 );
            var result = _mapper.Map<IList<ComponentBasicDTO>>(components);
            Response.Headers.Add("XItemCount", components.TotalItemCount.ToString());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetComponent")]
        public async Task<IActionResult> GetComponent(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var component = await _unitOfWork.Components.Get(q =>
                    q.Id == id
                    //, new List<string> { "TaskCategories" }
                );
            if (component == null) return NotFound();
            var result = _mapper.Map<ComponentBasicDTO>(component);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComponent([FromBody] CreateComponentDTO componentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var component = _mapper.Map<Component>(componentDTO);
            await _unitOfWork.Components.Insert(component);

            return CreatedAtRoute("GetComponent", new { id = component.Id }, _mapper.Map<ComponentBasicDTO>(component));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComponent(int id, [FromBody] CreateComponentDTO componentDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var component = await _unitOfWork.Components.Get(q => q.Id == id);
            if (component == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            component = _mapper.Map<Component>(componentDTO);
            component.Id = id;
            _unitOfWork.Components.Update(component);

            return CreatedAtRoute("GetComponent", new { id = id }, _mapper.Map<ComponentBasicDTO>(component));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponent(int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var component = await _unitOfWork.Components.Get(q => q.Id == id);
            if (component == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            await _unitOfWork.Components.Delete(component.Id);

            return Ok();
        }
    }
}

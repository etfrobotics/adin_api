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
    public class ImagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImagesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchImages([FromQuery] RequestParams requestParams, [FromQuery] string search="")
        {
            var images = await _unitOfWork.Images.GetAll(requestParams, q =>
                     q.Name.Contains(search)
                 );
            var result = _mapper.Map<IList<ImageDTO>>(images);
            Response.Headers.Add("XItemCount", images.TotalItemCount.ToString());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetImage")]
        public async Task<IActionResult> GetImage(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _unitOfWork.Images.Get(q =>
                    q.Id == id
                );
            if (image == null) return NotFound();
            var result = _mapper.Map<ImageDTO>(image);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage([FromBody] CreateImageDTO imageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var image = _mapper.Map<Image>(imageDTO);
            await _unitOfWork.Images.Insert(image);

            return CreatedAtRoute("GetImage", new { id = image.Id }, _mapper.Map<ImageDTO>(image));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(int id, [FromBody] CreateImageDTO imageDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _unitOfWork.Images.Get(q => q.Id == id);
            if (image == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            image = _mapper.Map<Image>(imageDTO);
            image.Id = id;
            _unitOfWork.Images.Update(image);

            return CreatedAtRoute("GetImage", new { id = id }, _mapper.Map<ImageDTO>(image));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _unitOfWork.Images.Get(q => q.Id == id);
            if (image == null)
            {
                var message = $"Submitted data is invalid";
                //_logger.LogError(message);
                return BadRequest(message);
            }

            await _unitOfWork.Images.Delete(image.Id);

            return Ok();
        }
    }
}

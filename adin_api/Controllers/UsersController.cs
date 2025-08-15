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
using Microsoft.AspNetCore.Identity;
using X.PagedList;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace adin_api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchUsers([FromQuery] RequestParams requestParams, [FromQuery] string search="")
        {
            var q = _userManager.Users;
            q = q.Where(a => a.UserName.Contains(search) || a.Email.Contains(search) || a.FirstName.Contains(search) || a.LastName.Contains(search));
            var users = await q.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
            Response.Headers.Add("XItemCount", users.TotalItemCount.ToString());
            var result = _mapper.Map<IList<UserWithRolesDTO>>(users);
            foreach (var r in result)
            {
                r.Roles = await _userManager.GetRolesAsync(_mapper.Map<User>(r));
            }
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userManager.Users.Where(q => q.Id == id);
            if (!user.Any()) return NotFound();
            var u = user.FirstOrDefault();
            var result = _mapper.Map<UserWithRolesDTO>(u);
            result.Roles = await _userManager.GetRolesAsync(u);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if ((await _userManager.FindByEmailAsync(userDTO.Email)) != null) return BadRequest("User already exist!");
            var user = _mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            user.LockoutEnabled = false;
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, new string[] { "User" });
            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] RegisterUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.LockoutEnabled = false;
            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, userDTO.Password);

            return Accepted();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userManager.Users.Where(q => q.Id == id).FirstOrDefault();
            if (user == null)
            {
                var message = $"Submitted data is invalid";
                return BadRequest(message);
            }
            if (await _userManager.IsInRoleAsync(user, "Administrator")) return BadRequest("Can't delete an administrator");

            await _userManager.DeleteAsync(user);
            await _unitOfWork.Context.SaveChangesAsync();

            return Ok();
        }
    }
}

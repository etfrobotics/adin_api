using adin_api.Data.Models;
using adin_api.DTOs;
using adin_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _autManager;

        public AccountController(
            UserManager<User> userManager,
            IMapper mapper,
            IAuthManager authManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _autManager = authManager;
        }

        [HttpPost]
        [Route("api/Register")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userDTO)
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

        [HttpPost]
        [Route("api/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _autManager.ValidateUser(userDTO))
            {
                return Unauthorized(userDTO);
            }
            var u = await _userManager.FindByEmailAsync(userDTO.Email);

            return Accepted(new
            {
                token = await _autManager.CreateToken(),
                ExpiresIn = _autManager.ExpiresIn(),
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Roles = await _autManager.GetRoles()
            });
        }
    }
}

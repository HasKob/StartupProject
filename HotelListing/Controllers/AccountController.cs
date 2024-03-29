﻿
using AutoMapper;
using HotelListing.Database;
using HotelListing.Core.DTOs;
using HotelListing.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HotelListing.Core.Models;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        public AccountController(UserManager<ApiUser> userManager, ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            _logger.LogInformation($"{nameof(Register)} attempt for {apiUserDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var apiUser = _mapper.Map<ApiUser>(apiUserDto);
            apiUser.UserName = apiUserDto.Email;
            var result = await _userManager.CreateAsync(apiUser, apiUserDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(apiUser, apiUserDto.Roles);
            return Accepted();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] ApiUserLoginDto apiUserLoginDto)
        {
            _logger.LogInformation($"{nameof(Login)} attempt for {apiUserLoginDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _authManager.ValidateUser(apiUserLoginDto))
            {
                return Unauthorized();
            }
            return Accepted(new TokenRequest { Token = await _authManager.CreateToken(), RefreshToken = await _authManager.CreateRefreshToken() });
        }
        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var tokenRequest  = await _authManager.VerifyRefreshToken(request);
            if (tokenRequest is null)
            {
                return Unauthorized();
            }
            return Ok(tokenRequest);
        }
    }
}

using AutoMapper;
using ECommerce.Core.Application.Commands;
using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Dtos.User;
using ECommerce.Infrastructure.API.Configuration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthOptions _authOptions;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        //private readonly IUserInfoRepository _repository;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMediator _mediator;

        public AccountController(IOptions<AuthOptions> options, UserManager<User> userManager,
                                 SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager,
                                 IMediator mediator)
        {
            _authOptions = options.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            //_repository = repository;
            _roleManager = roleManager;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserSignInDto userSignInDto)
        {
            Microsoft.AspNetCore.Identity.SignInResult checkingPasswordResult;
            var userByEmail = await _userManager.FindByEmailAsync(userSignInDto.UserName);

            if (userByEmail != null)
            {
                checkingPasswordResult = await _signInManager.PasswordSignInAsync(
                    userByEmail.UserName, userSignInDto.Password, false, false);
            }
            else
            {
                checkingPasswordResult = await _signInManager.PasswordSignInAsync(
                    userSignInDto.UserName, userSignInDto.Password, false, false);
            }

            if (checkingPasswordResult.Succeeded)
            {
                User user;

                if (userByEmail == null)
                {
                    user = await _userManager.FindByNameAsync(userSignInDto.UserName);
                }
                else
                {
                    user = await _userManager.FindByEmailAsync(userSignInDto.UserName);
                }

                var userId = user.Id;
                var userRoles = await _userManager.GetRolesAsync(user);
                var encodedToken = GetJwtSecurityToken(userId, userRoles as List<string>);

                return Ok(new { AccessToken = encodedToken });
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SingUp.SingUpCommand request)
        {
            var respons = await _mediator.Send(request);

            if (respons.Result == IdentityResult.Success)
            {
                return Ok(new { respons.UserName, respons.Password });
            }

            return BadRequest(respons.Result.Errors); ;
        }

        // TODO: Fix
        //[HttpPost("logout")]
        ////[ValidateAntiForgeryToken]
        //public async Task Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //}

        private string GetJwtSecurityToken(Guid userId, List<string> roles)
        {
            List<Claim> _claims = new List<Claim>() { new Claim("UserId", userId.ToString()) };
            roles.ForEach(r => _claims.Add(new Claim("Role", r)));

            var signingCredentials = new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                claims: _claims,
                //expires: DateTime.Now.AddDays(30),
                expires: DateTime.Now.AddSeconds(_authOptions.TokenLifetime),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private async Task<IdentityResult> EnsureRole(string userId, string role)
        {
            IdentityResult IR = null;

            if (!await _roleManager.RoleExistsAsync(role))
            {
                IR = await _roleManager.CreateAsync(new Role(role));
                if (!IR.Succeeded)
                {
                    throw new Exception($"Could not create role {role}");
                }
            }

            var user = await _userManager.FindByIdAsync(userId);

            IR = await _userManager.AddToRoleAsync(user, role);

            return IR;
        }

        //private async Task<ActionResult<UserInfo>> CreateUserInfo(UserForUpdateDto userForUpdateDto, int userId)
        //{
        //    var userInfo = _mapper.Map<UserInfo>(userForUpdateDto);
        //    userInfo.OwnerId = userId;

        //    await _repository.Add(userInfo);
        //    await _repository.SaveChangesAsync();

        //    return Ok(userInfo);
        //}

        //private string GetJwtSecurityToken(int userId)
        //{
        //    List<Claim> _claims = new List<Claim>() { new Claim("UserId", userId.ToString()) };

        //    var signingCredentials = new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
        //    var jwtSecurityToken = new JwtSecurityToken(
        //        issuer: _authOptions.Issuer,
        //        audience: _authOptions.Audience,
        //        claims: _claims,
        //        expires: DateTime.Now.AddDays(30),
        //        signingCredentials: signingCredentials
        //    );

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    return tokenHandler.WriteToken(jwtSecurityToken);
        //}
    }
}

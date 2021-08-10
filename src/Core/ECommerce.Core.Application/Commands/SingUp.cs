using ECommerce.Core.DataAccess.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.Commands
{
    public class SingUp
    {
        public class SingUpCommand : IRequest<SignUpResponse>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }

        public class SignUpHandler : IRequestHandler<SingUpCommand, SignUpResponse>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            private readonly RoleManager<Role> _roleManager;

            public SignUpHandler(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _roleManager = roleManager;
            }
            public async Task<SignUpResponse> Handle(SingUpCommand request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    IsActive = true
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                // TODO: Remove
                IdentityResult IR = null;

                if (!await _roleManager.RoleExistsAsync("user"))
                {
                    IR = await _roleManager.CreateAsync(new Role("user"));
                    if (!IR.Succeeded)
                    {
                        throw new Exception($"Could not create role role");
                    }
                }

                // -----------

                if (result == IdentityResult.Success)
                {
                    await _userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                    await _userManager.AddToRoleAsync(user, "user");

                    return new SignUpResponse()
                    {
                        UserName = user.UserName,
                        Password = request.Password,
                        Result = result
                    };
                }
                return new SignUpResponse()
                {
                    Result = result
                };
            }
        }
        public class SignUpResponse
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public IdentityResult Result { get; set; }

        }
    }
}
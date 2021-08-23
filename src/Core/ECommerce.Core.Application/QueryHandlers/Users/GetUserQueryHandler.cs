using AutoMapper;
using ECommerce.Core.Application.Queries.Users;
using ECommerce.Core.DataAccess.Auth;
using ECommerce.Core.DataAccess.Dtos.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.QueryHandlers.Users
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        //private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IMapper mapper/*, UserManager<User> userManager*/)
        {
            _mapper = mapper;
            //_userManager = userManager;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.FindByIdAsync(request.Id.ToString());

            //var result = _mapper.Map<UserDto>(user);

            //return result;

            return new UserDto();
        }
    }
}

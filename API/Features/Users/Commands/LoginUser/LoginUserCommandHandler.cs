using DixRacing.Domain.Users.Commands.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly ILoginUserService _loginUserService;

        public LoginUserCommandHandler(ILoginUserService loginUserService)
        {
            _loginUserService = loginUserService;
        }

        public Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dto = new LoginUserDto(request.Email,request.Password);
            return  _loginUserService.ExecuteAsync(dto);
        }    
    }
}

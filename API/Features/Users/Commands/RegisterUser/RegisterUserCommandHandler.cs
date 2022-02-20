using DixRacing.Domain.Users.Commands;
using DixRacing.Domain.Users.Commands.Register;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Features.Users.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IRegisterUserService _registerUserService;

        public RegisterUserCommandHandler(IRegisterUserService registerUserService)
        {
            _registerUserService = registerUserService;
        }
        public Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return _registerUserService.ExecuteAsync(request.registerUserDto);
        }
    }
}

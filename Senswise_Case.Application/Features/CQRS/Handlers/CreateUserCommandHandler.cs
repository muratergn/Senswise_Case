using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senswise_Case.Application.Features.CQRS.Commands;
using Senswise_Case.Application.Interfaces;
using Senswise_Case.Domain.Entities;

namespace Senswise_Case.Application.Features.CQRS.Handlers
{
    public class CreateUserCommandHandler
    {
        private readonly IRepository<User> _repository;

        public CreateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateUserCommand command)
        {
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Address = command.Address
            };
            await _repository.AddAsync(user);
        }
    }
}

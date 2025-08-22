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
    public class UpdateUserCommandHandler
    {
        private readonly IRepository<User> _repository;
        public UpdateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateUserCommand command)
        {
            var user = await _repository.GetByIdAsync(command.Id);
            if (user != null)
            {
                user.FirstName = command.FirstName;
                user.LastName = command.LastName;
                user.Email = command.Email;
                user.Address = command.Address;
                await _repository.UpdateAsync(user);
            }
        }
    }
}

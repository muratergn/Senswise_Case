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
    public class RemoveUserCommandHandler
    {
        private readonly IRepository<User> _repository;
        public RemoveUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveUserCommand from)
        {
            var user = await _repository.GetByIdAsync(from.Id);
            if (user != null)
            {
                await _repository.DeleteAsync(user);
            }
        }
    }
}

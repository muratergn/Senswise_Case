using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senswise_Case.Application.Interfaces;
using Senswise_Case.Domain.Entities;

namespace Senswise_Case.Application.Features.CQRS.Handlers
{
    public class GetUserQueryHandler
    {
        private readonly IRepository<User> _repository;

        public GetUserQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> Handle()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(user => new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            }).ToList();
        }
    }
}

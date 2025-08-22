using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senswise_Case.Application.Features.CQRS.Queries;
using Senswise_Case.Application.Features.CQRS.Results;
using Senswise_Case.Application.Interfaces;
using Senswise_Case.Domain.Entities;

namespace Senswise_Case.Application.Features.CQRS.Handlers
{
    public class GetUserByIdQueryHandler
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery from)
        {
            var user = await _repository.GetByIdAsync(from.Id);
            if (user == null)
            {
                return null;
            }
            return new GetUserByIdQueryResult
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            };
        }
    }
}

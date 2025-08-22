using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senswise_Case.Application.Features.CQRS.Commands
{
    public class RemoveUserCommand
    {
        public Guid Id { get; set; }
        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }
    }
}

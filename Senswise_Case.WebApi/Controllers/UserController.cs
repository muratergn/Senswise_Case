using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senswise_Case.Application.Features.CQRS.Commands;
using Senswise_Case.Application.Features.CQRS.Handlers;
using Senswise_Case.Application.Features.CQRS.Queries;

namespace Senswise_Case.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUserCommandHandler _createUserCommandHandler;
        private readonly GetUserByIdQueryHandler _getUserByIdQueryHandler;
        private readonly GetUserQueryHandler _getUserQueryHandler;
        private readonly UpdateUserCommandHandler _updateUserCommandHandler;
        private readonly RemoveUserCommandHandler _removeUserCommandHandler;

        public UserController(
            CreateUserCommandHandler createUserCommandHandler,
            GetUserByIdQueryHandler getUserByIdQueryHandler,
            GetUserQueryHandler getUserQueryHandler,
            UpdateUserCommandHandler updateUserCommandHandler,
            RemoveUserCommandHandler removeUserCommandHandler)
        {
            _createUserCommandHandler = createUserCommandHandler;
            _getUserByIdQueryHandler = getUserByIdQueryHandler;
            _getUserQueryHandler = getUserQueryHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _removeUserCommandHandler = removeUserCommandHandler;
        }

        [HttpGet]
        public IActionResult GetUserList()
        {
            var result = _getUserQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("user/{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var result = _getUserByIdQueryHandler.Handle(new GetUserByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserCommand command)
        {
            _createUserCommandHandler.Handle(command);
            return Ok("User başarılı eklendi");
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserCommand command)
        {
            _updateUserCommandHandler.Handle(command);
            return Ok("User başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser([FromBody] RemoveUserCommand command)
        {
            _removeUserCommandHandler.Handle(command);
            return Ok("User silindi");
        }


    }
}

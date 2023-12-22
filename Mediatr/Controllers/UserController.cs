using Mediator.Commands;
using Mediator.Domains;
using Mediator.Interface;
using Mediator.Queries;
using Mediatr.Domains;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserRepository _userRepository;
    public UserController(IMediator mediator, IUserRepository userRepository)
    {
        _mediator = mediator;
        _userRepository = userRepository;
    }
    [HttpPost("register")]
    public async Task<ActionResult<UserDetail>> Register(UserDto request) => Ok(await _userRepository.Register(request));

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserDto request) => Ok(await _userRepository.Login(request));

    [HttpGet("ListUsers"), Authorize]
    public async Task<List<UserDetail>> GetUserListAsync()
    {
        var studentdetails = await _mediator.Send(new GetUserListQuery());
        return studentdetails;
    }

    [HttpGet("userId")]
    public async Task<UserDetail> GetUserByIdAsync(string UserId)
    {
        var studentDetails = await _mediator.Send(new GetUserByIdQuery() { Id = UserId });

        return studentDetails;
    }
    [HttpPost]
    public async Task<UserDetail> AddUserAsync(UserDto userDetails)
    {
        var studentDetail = await _mediator.Send(new CreateUserCommand(
            userDetails.Name,
            userDetails.Email,
            userDetails.Password,
            userDetails.Role
            ));
        return studentDetail;
    }

    [HttpPut]
    public async Task<int> UpdateUserAsync(UserDetail userDetails)
    {
        var isStudentDetailUpdated = await _mediator.Send(new UpdateUserCommand(
            userDetails.Id,
            userDetails.UserName,
            userDetails.Email,
            userDetails.PasswordHash,
            ERole.Admin
            ));
        return isStudentDetailUpdated;
    }

    [HttpDelete]
    public async Task<int> DeleteUserAsync(string Id)
    {
        return await _mediator.Send(new DeleteUserCommand() { Id = Id });
    }
}

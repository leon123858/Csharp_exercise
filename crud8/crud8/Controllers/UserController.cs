using Microsoft.AspNetCore.Mvc;

namespace crud8.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // GET: api/User
    [HttpGet]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userService.GetAllUsersAsync();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(CreateUserRequest user)
    {
        var fullUser = new User
        {
            Name = user.Name,
            Age = user.Age
        };
        var createdUser = await _userService.CreateUserAsync(fullUser);
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
    }

    // PUT: api/User/5
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        var updatedUser = await _userService.UpdateUserAsync(user);
        if (updatedUser == null)
        {
            return NotFound();
        }

        return updatedUser;
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var success = await _userService.DeleteUserAsync(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
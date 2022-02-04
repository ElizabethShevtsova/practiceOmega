using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omega.Models;
using Omega.Repositories;

namespace Omega.Controllers;

public class AuthorizationController : Controller
{
    private readonly IUserRepository _userRepository;

    public AuthorizationController(IUserRepository userRepository)
    {
        _userRepository = userRepository;

    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersList()
    {
        var users = await _userRepository.GetAll();
        return Ok(users);
    }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<User>> GetUsers(int id)
    {
        var _id = await _userRepository.Get(id);
        //if (_id == null)
            //return NotFound();
        return Ok(_id);
    }
}
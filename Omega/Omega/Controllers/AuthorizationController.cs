using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omega.Models;
using Omega.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace Omega.Controllers;

public class AuthorizationController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IModelsContext _context;
    private readonly IMapper _mapper;

    public AuthorizationController(IUserRepository userRepository,IMapper mapper,IModelsContext context)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _context = context;

    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersList()
    {
        var users = await _userRepository.GetAll();
        return Ok(users);
    }
    [HttpGet ("getpas")]
    public async Task<ActionResult<User>> GetSplit(AutorizationDto model)
    {
        string pas = model.password.Split("$")[0];
        return Ok(pas);
    }
    
    
    [HttpPost ("Autorization")]
    public async Task<IActionResult> Login(AutorizationDto model)
    {
        var user = _context.users.SingleOrDefault(x => x.login == model.login);
        if (user == null || model.password!=user.password.Split("$")[0])
            throw new Exception("Username or password is incorrect");
        
        var response = _mapper.Map<AutorizationDto>(user);
        return Ok(response);
    }
    

}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Omega.Models;
using Omega.Repositories;
using Omega.ViewModels;
using Omega.ViewModelsModels;

namespace Omega.Controllers;

public class RegistrationController : Controller
{
    
    private readonly IDataRepository _dataRepository;
    private readonly IMapper _mapper;
    private readonly IModelsContext _context;

    public RegistrationController(IDataRepository dataRepository, IMapper mapper,IModelsContext context)
    {
       
        _dataRepository = dataRepository;
        _mapper = mapper;
        _context = context;

    }
    [HttpGet ("GetUser")]
    public async Task<ActionResult<IEnumerable<User>>> GetUser()
    {
        var users = await _dataRepository.GetUser();
        return Ok(users);
    }
    [HttpGet("GetData")]
    public async Task<ActionResult<IEnumerable<Data>>> GetData()
    {
        var datas = await _dataRepository.GetData();
        return Ok(datas);
    }
    
    [HttpPost ("Data")]
    public async Task<ActionResult> CreateData(DataViewModel datas)
    {
        Data data = _mapper.Map<Data>(datas);
        await _dataRepository.AddData(data);
        return Ok();
    }
    
    [HttpPost ("User")]
    public async Task<ActionResult> CreateUser(UserViewModel userViewModel)
    {
      
        if (_context.users.Any(x => x.login == userViewModel.login))
            throw new Exception("Username '" + userViewModel.login + "' is already taken");

      
        var user = _mapper.Map<User>(userViewModel);

       
        user.password = userViewModel.password+BCrypt.Net.BCrypt.HashPassword(userViewModel.password);
       
        await _dataRepository.AddUser(user);
        return Ok();
    }
 
    
    [HttpPut("UpdateData")]
    public async Task<ActionResult> Edit(DataViewModel dataView)
    {
        Data model=_mapper.Map<Data>(dataView);
        await _dataRepository.UpdateData(model);
        return Ok();
    }
    [HttpPut("UpdateUser")]
    public async Task<ActionResult> UpdateUser(UserViewModel updateUser)
    {
        var user= _context.users.Find(updateUser.userId);
        if (user == null)
            throw new KeyNotFoundException("User not found");
        _mapper.Map(updateUser,user);
        user.password = updateUser.password+BCrypt.Net.BCrypt.HashPassword(updateUser.password);
        _context.users.Update(user);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete("DeleteUserId")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _dataRepository.DeleteUser(id);
        return Ok();
    }
    [HttpDelete("DeleteDataId")]
    public async Task<ActionResult> DeleteData(int id)
    {
        await _dataRepository.DeleteData(id);
        return Ok();
    }
}
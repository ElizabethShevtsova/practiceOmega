using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omega.Models;
using Omega.Repositories;

namespace Omega.Controllers;

public class RegistrationController : Controller
{
    
    private readonly IDataRepository _dataRepository;

    public RegistrationController(IDataRepository dataRepository)
    {
       
        _dataRepository = dataRepository;

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
    public async Task<ActionResult> CreateData(CreateData createData)
    {
        Data data = new()
        {
            id= createData.id,
            surname = createData.surname,
            name = createData.name,
            address = createData.address,
            phone = createData.phone

        };
        await _dataRepository.AddData(data);
        return Ok();
    }
    
    [HttpPost ("User")]
    public async Task<ActionResult> CreateUser(CreateUser createUser)
    {
        User user = new()
        {
            userId = createUser.userId,
            login = createUser.login,
            password = createUser.password

        };
        await _dataRepository.AddUser(user);
        return Ok();
    }
   
   
   
    [HttpPut("UpdateData")]
    public async Task<ActionResult> UpdateData (int id,UpdateData updateData)
    {
        Data data = new()
        {
            id= id,
            surname = updateData.surname,
            name = updateData.name,
            address = updateData.address,
            phone = updateData.phone

        };
        await _dataRepository.UpdateData(data);
        return Ok();
    }
    [HttpPut("UpdateUser")]
    public async Task<ActionResult> UpdateUser(int id,UpdateUser updateUser)
    {
        User user = new()
        {
            userId = id,
            login = updateUser.login,
            password = updateUser.password
        };
        await _dataRepository.UpdateUser(user);
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
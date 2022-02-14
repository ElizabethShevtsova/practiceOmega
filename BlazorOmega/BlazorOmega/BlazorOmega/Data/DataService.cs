using System.Linq;
using AutoMapper;
using BlazorOmega.Data.Service;
using BlazorOmega.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace BlazorOmega.Data;

public class DataService:IDataService
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public DataService(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public void CreateData(DataViewModel datac)
    {
        Data data = _mapper.Map<Data>(datac);
        _context.datas.Add(data);
        _context.SaveChanges();
       
        
    }

    public void CreateUser(DataViewModel data, UserViewModel user)
    {
        if (_context.users.Any(x => x.login == user.login))
            throw new Exception("Username '" + user.login + "' is already taken");

      
        var users = _mapper.Map<User>(user);

        users.userId = data.id;
        users.password = BCrypt.Net.BCrypt.HashPassword(user.password);
        _context.users.Add(users);
        _context.SaveChanges();
        
    }

    public IEnumerable<Data> GetAllItems()
    {
        return _context.datas;
    }

    public bool Authorization(UserViewModel model)
    {
        bool status = false;
        var user = _context.users.SingleOrDefault(x => x.login == model.login);
        if (user == null || !BCrypt.Net.BCrypt.Verify(model.password, user.password))
        
            throw new Exception("Incorrect login or password");
        
        
        _mapper.Map<UserViewModel>(user);
        status = true; 

        return status;

    }
       



}

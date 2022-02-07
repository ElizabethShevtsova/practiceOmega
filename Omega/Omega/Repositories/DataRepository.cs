using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Omega.Models;
using Omega.ViewModels;
using Omega.ViewModelsModels;

namespace Omega.Repositories;

public class DataRepository:IDataRepository
{
    private readonly IModelsContext _context;
    private readonly IMapper _mapper;

    public DataRepository(IModelsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<User>> GetUser()
    {
        return await _context.users.ToListAsync();
    }

    public async Task<IEnumerable<Data>> GetData()
    {
        return await _context.datas.ToListAsync();
    }

    public async Task<Data> GetDataId(int id)
    {
        return await _context.datas.FindAsync(id);
    }
    public async Task AddUser(User user)
    {
        _context.users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task AddData(Data data)
    {
        _context.datas.Add(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteData(int id)
    {
        var item = await _context.datas.FindAsync(id);
        if (item == null)
            throw new NullReferenceException();
        _context.datas.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var itemUser = await _context.users.FindAsync(id);
        if (itemUser == null)
            throw new NullReferenceException();
        _context.users.Remove(itemUser);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateData(Data data)
    {
        var itemUpUser = await _context.datas.FindAsync(data.id);
        if (itemUpUser == null)
            throw new NullReferenceException();
        
        itemUpUser.surname = data.surname;
        itemUpUser.name = data.name;
        itemUpUser.address = data.address;
        itemUpUser.phone = data.phone;
        await _context.SaveChangesAsync();

    }

    public async Task UpdateUser(User user)
    {
        await _context.SaveChangesAsync();
    }
}
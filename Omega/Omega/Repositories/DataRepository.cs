using Microsoft.EntityFrameworkCore;
using Omega.Models;

namespace Omega.Repositories;

public class DataRepository:IDataRepository
{
    private readonly IModelsContext _context;

    public DataRepository(IModelsContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetUser()
    {
        return await _context.users.ToListAsync();
    }

    public async Task<IEnumerable<Data>> GetData()
    {
        return await _context.datas.ToListAsync();
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
        var itemUpData = await _context.datas.FindAsync(data.id);
        if (itemUpData == null)
            throw new NullReferenceException();
        itemUpData.surname = data.surname;
        itemUpData.name = data.name;
        itemUpData.address = data.address;
        itemUpData.phone = data.phone;
        await _context.SaveChangesAsync();

    }

    public async Task UpdateUser(User user)
    {
        var itemUpUser = await _context.users.FindAsync(user.userId);
        if (itemUpUser == null)
            throw new NullReferenceException();
        itemUpUser.login = user.login;
        itemUpUser.password = user.password;
        await _context.SaveChangesAsync();
    }
}
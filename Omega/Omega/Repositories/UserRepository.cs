using Microsoft.EntityFrameworkCore;
using Omega.Models;

namespace Omega.Repositories;

public class UserRepository:IUserRepository
{
    private readonly IModelsContext _context;

    public UserRepository(IModelsContext context)
    {
        _context = context;
    }
    public async Task<User> Get(int id)
    {
        return await _context.users.FindAsync(id);

    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.users.ToListAsync();
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omega.Models;
using BCrypt.Net;

namespace Omega.Repositories;

public class UserRepository:IUserRepository
{
    private readonly IModelsContext _context;
    private readonly IMapper _mapper;

    public UserRepository(IModelsContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
   

 

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.users.ToListAsync();
    }
}
using Omega.Models;

namespace Omega.Repositories;

public interface IUserRepository
{
    
    Task<User> Get(int id);
    Task<IEnumerable<User>> GetAll();
}
using Omega.Models;

namespace Omega.Repositories;

public interface IUserRepository
{
    
   
    Task<IEnumerable<User>> GetAll();
}
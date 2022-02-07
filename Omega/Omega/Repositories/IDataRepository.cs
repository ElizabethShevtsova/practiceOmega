using Omega.Models;
using Omega.ViewModels;

namespace Omega.Repositories;

public interface IDataRepository
{
    Task<IEnumerable<User>> GetUser();
    Task<IEnumerable<Data>> GetData();
    Task AddUser(User user);
    Task AddData(Data data);
    Task DeleteData(int id);
    Task DeleteUser(int id);
    Task <Data> GetDataId(int id);
    Task UpdateData(Data data);
    
    Task UpdateUser(User user);
}
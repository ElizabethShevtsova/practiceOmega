using BlazorOmega.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BlazorOmega.Data.Service;

public interface IDataService
{
    public void CreateData(DataViewModel datac);
    public void CreateUser(DataViewModel data, UserViewModel user);

    IEnumerable<Data> GetAllItems();
    public bool Authorization(UserViewModel model);

}
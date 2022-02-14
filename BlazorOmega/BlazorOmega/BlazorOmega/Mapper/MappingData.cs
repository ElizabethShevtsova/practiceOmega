using AutoMapper;
using BlazorOmega.Data;
using BlazorOmega.Data.ViewModel;

namespace DefaultNamespace;

public class MappingData:Profile
{
    public MappingData()
    {
       CreateMap<Data, DataViewModel>();
       CreateMap<DataViewModel,Data>();
       CreateMap<User, UserViewModel>();
       CreateMap<UserViewModel, User>();
       

    }
}
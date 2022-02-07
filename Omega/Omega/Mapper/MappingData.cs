using AutoMapper;
using Omega.Models;
using Omega.ViewModels;
using Omega.ViewModelsModels;

namespace Omega.Mapper;

public class MappingData:Profile
{
    public MappingData()
    {
        CreateMap<Data, DataViewModel>();
        CreateMap<DataViewModel,Data>();
        CreateMap<User, UserViewModel>();
        CreateMap<UserViewModel, User>();
        CreateMap<AutorizationDto, User>();
        CreateMap<User,AutorizationDto>();

    }
}
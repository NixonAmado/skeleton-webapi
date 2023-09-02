using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public  MappingProfiles()
    {
        CreateMap<ClassRoom,ClassRoomDto>().ReverseMap();
        CreateMap<Country,CountryDto>().ReverseMap();
        CreateMap<Gender,GenderDto>().ReverseMap();
        CreateMap<Person,PersonDto>().ReverseMap();
        CreateMap<PersonType,PersonTypeDto>().ReverseMap();
        CreateMap<Region,RegionDto>().ReverseMap();
        CreateMap<State,StateDto>().ReverseMap();
        CreateMap<Gender,GenderDto>().ReverseMap();
    
    }
}


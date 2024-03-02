using AutoMapper;
using SpaSalon.Database.Entities;
using SpaSalon.Models;

namespace SpaSalon
{
    public class SpaSalonMappingProfile : Profile
    {
        public SpaSalonMappingProfile()
        {
            CreateMap<CreateMassageDto, MassageName>();
            CreateMap<RegisterUserDto, User>()
              .ForMember(u => u.HashPassword, options => options.MapFrom(dto => dto.Password));
            CreateMap<UpdateMassageDto, MassageName>();
            CreateMap<RegisterUserDto, AdminAccountDto>();
            CreateMap<UpdateRoleDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}

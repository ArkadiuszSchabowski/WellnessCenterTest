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
        }
    }
}

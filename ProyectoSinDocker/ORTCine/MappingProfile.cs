using AutoMapper;
using ORTCine.Models;
using ORTCine.ViewModel;

namespace ORTCine
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, Cliente>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}

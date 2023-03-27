using Application.Toilets;
using AutoMapper;
using Domain;
namespace Application.Core;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<Toilet, Toilet>();
        CreateMap<Toilet, ToiletDto>()
            .ForMember(d => d.Creator, o => o.MapFrom(s => s.Creator))
            .ForMember(d => d.ToiletModifiers, o => o.MapFrom(s => s.ToiletModifiers))
            .ForMember(d => d.Poopers, o => o.MapFrom(s => s.Poopers));
        CreateMap<AppUser, Profile.Profile>()
            .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.DisplayName))
            .ForMember(d => d.Username, o => o.MapFrom(s => s.UserName))
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        CreateMap<Pooper, Profile.Profile>()
            .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
            .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName));
    }
}
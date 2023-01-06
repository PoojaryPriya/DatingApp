using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUserClass , MemberDto>()
            .ForMember(dest=>dest.PhotoUrl,
            op=>op.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url))
            .ForMember(dest=>dest.Age,op=>op.MapFrom(src=>src.DateOfBirth.CalcualateAge()));
            CreateMap<Photo,PhotoDto>();
            CreateMap<MemberUpdateDto, AppUserClass>();
        }
    }
}
using AutoMapper;
using SpaceWalk.Dtos;
using SpaceWalk.Models;

namespace SpaceWalk.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<RegisterModel, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
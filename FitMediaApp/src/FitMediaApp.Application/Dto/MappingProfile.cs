using AutoMapper;
using FitMediaApp.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDto>();
            CreateMap<Post, PostDto> ();
            CreateMap<Comment, CommentDto> ();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserDtoForComment>();
            CreateMap<Follower, FollowerDto>();
        }
    }
}

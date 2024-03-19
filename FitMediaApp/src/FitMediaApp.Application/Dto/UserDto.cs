using FitMediaApp.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Dto
{

        public record UserDto(
            Guid Guid,
            string Username,
            string Mail,
            string ProfilePicPath,
            string? Bio,
            List<PostDto> Posts,
            List<FollowerDto> FollowerSender,
            List<FollowerDto> FollowerRecipient
            );
        }
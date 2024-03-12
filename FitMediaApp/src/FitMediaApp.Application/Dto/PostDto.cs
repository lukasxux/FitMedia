using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FitMediaApp.Application.Dto
{

        public record PostDto(
        Guid Guid,
        DateTime Date,
        string FilePathPic,
        string Description,
        List<CommentDto> Comments,
        List<UserDto> Likes
    );
}
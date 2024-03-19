using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Dto
{
    public record UserDtoForComment
    (
         Guid Guid,
         string Username,
         string Mail,
         string ProfilePicPath,
         string? Bio
    );
}

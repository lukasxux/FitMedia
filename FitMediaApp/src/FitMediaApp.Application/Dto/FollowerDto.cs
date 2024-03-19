using FitMediaApp.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Dto
{
    public record FollowerDto(
        UserDtoForComment sender, UserDtoForComment recipient, DateTime dateTime
        );
}

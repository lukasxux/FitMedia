using FitMediaApp.Application.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitMediaApp.Application.Dto
{
    public record UserRegisterDto(
    string Username,
    string Mail,
    string ProfilePicPath,
    String? Bio,
    string initialPasswords
    );
}
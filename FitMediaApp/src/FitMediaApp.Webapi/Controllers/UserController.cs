using FitMediaApp.Application.Infastrucure;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using FitMediaApp.Application.Dto;
using FitMediaApp.Application.Model;

namespace FitMediaApp.Webapi.Controllers
{
   
    public class UserController : EntityReadController<User>
    {
        public UserController(FitMediaContext db, IMapper mapper) : base(db, mapper)
        {
        }


    }
}

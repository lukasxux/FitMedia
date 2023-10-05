using FitMediaApp.Application.Infastrucure;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitMediaApp.Application.Model;

namespace FitMediaApp.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityReadController<TEntity> : ControllerBase where TEntity : class, IEntity
    {
        protected readonly FitMediaContext _db;
        protected readonly IMapper _mapper;
        protected EntityReadController(FitMediaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        protected async Task<IActionResult> GetAll<TDto>(Expression<Func<TEntity, TDto>> projection)
        {
            var result = await _db.Set<TEntity>()
                .Select(projection)
                .ToListAsync();
            return Ok(result);
        }

        protected async Task<IActionResult> GetAll<TDto>()
        {
            var result = await _mapper
                .ProjectTo<TDto>(_db.Set<TEntity>())
                .ToListAsync();
            return Ok(result);
        }

        protected async Task<IActionResult> GetByGuid<TDto>(Guid guid)
        {
            var result = await _mapper.ProjectTo<TDto>(_db.Set<TEntity>().Where(e => e.Guid == guid))
                .FirstOrDefaultAsync();
            if (result is null) return NotFound();
            return Ok(result);
        }

        protected async Task<IActionResult> GetByGuid<TDto>(Guid guid, Expression<Func<TEntity, TDto>> projection)
        {
            var result = await _db.Set<TEntity>()
                .Where(e=>e.Guid == guid)
                .Select(projection)
                .FirstOrDefaultAsync();
            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}

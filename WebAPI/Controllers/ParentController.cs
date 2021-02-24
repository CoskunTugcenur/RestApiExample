using Business.Abstract;
using Core.Business;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController<TService,TEntity> : ControllerBase
        where TService : class,IServiceBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        
        TService _service;

        public ParentController(TService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =_service.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
                
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(TEntity entity)
        {
            var result = _service.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(TEntity entity)
        {
            var result = _service.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TEntity entity)
        {
            var result = _service.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

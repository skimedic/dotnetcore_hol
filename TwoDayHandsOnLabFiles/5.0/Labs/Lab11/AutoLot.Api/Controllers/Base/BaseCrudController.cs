using System;
using System.Collections.Generic;
using AutoLot.Dal.Exceptions;
using AutoLot.Models.Entities.Base;
using AutoLot.Dal.Repos.Base;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseCrudController<T, TController> : ControllerBase
        where T : BaseEntity, new()
        where TController : BaseCrudController<T, TController>
    {
        protected readonly IRepo<T> MainRepo;
        protected readonly IAppLogging<TController> Logger;

        protected BaseCrudController(IRepo<T> repo, IAppLogging<TController> logger)
        {
            MainRepo = repo;
            Logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<T>> GetAll()
        {
            return Ok(MainRepo.GetAllIgnoreQueryFilters());
        }

        [HttpGet("{id}")]
        public ActionResult<T> GetOne(int id)
        {
            var entity = MainRepo.Find(id);

            if (entity == null)
            {
                return NoContent();
            }

            return Ok(entity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOne(int id,T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            try
            {
                MainRepo.Update(entity);
            }
            catch (CustomException ex)
            {
                //This shows an example with the custom exception
                //Should handle more gracefully
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                //Should handle more gracefully
                return BadRequest(ex);
            }

            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<T> AddOne(T entity)
        {
            try
            {
                MainRepo.Add(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return CreatedAtAction(nameof(GetOne), new {id = entity.Id}, entity);
        }

        [HttpDelete("{id}")]
        public ActionResult<T> DeleteOne(int id, T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            try
            {
                MainRepo.Delete(entity);
            }
            catch (Exception ex)
            {
                //Should handle more gracefully
                return new BadRequestObjectResult(ex.GetBaseException()?.Message);
            }

            return Ok();
        }
    }
}
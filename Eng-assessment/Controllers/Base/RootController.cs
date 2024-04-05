using Eng_assessment.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Entities.Base;

namespace Eng_assessment.Controllers.Base
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class RootController<TEntity, TService, TGetDto, TCreateDto, TUpdateDto> : ControllerBase
        where TEntity : DatabaseEntity
        where TService : IService<TEntity, TGetDto, TCreateDto, TUpdateDto>
        where TGetDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        protected readonly TService _service;

        protected RootController(TService service)
        {
            _service = service;
        }

        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TGetDto>>> GetAll()
        {
            try
            {
                IEnumerable<TGetDto> entities = await _service.GetAll();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/[controller]/{id}
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TGetDto>> GetById(long id)
        {
            try
            {
                var entity = await _service.GetById(id);
                return Ok(entity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/[controller]
        [HttpPost]
        public virtual async Task<ActionResult<TGetDto>> Create(TCreateDto entity)
        {
            try
            {
                TEntity resultEntity = await _service.Create(entity);
                //maintain restful convention and return 201 status code for created, the created entity and the location of the created entity
                return CreatedAtAction(nameof(GetById), new { id = resultEntity.Id }, resultEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/[controller]/{id}
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(long id, TUpdateDto entity)
        {
            try
            {
                var updatedEntity = await _service.Update(id, entity);
                return Ok(updatedEntity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                //Return an error action with the error message
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/[controller]/{id}
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _service.Delete(id);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

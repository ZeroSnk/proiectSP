using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.Repositories;
using System.Linq;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IEntityRepo _entityRepo;
        public EntityController(IEntityRepo entityRepo)
        {
            _entityRepo = entityRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<Entity>> GetEntities()
        {
            return await _entityRepo.GetAll();
        }
        [HttpGet("{CNP}")]
        public async Task<ActionResult<Entity>> GetEntities(string CNP)
        {

            var entityToDelete = await _entityRepo.Get(CNP);

                if (entityToDelete == null)
                {
                    return NotFound("“Agreement not found!”");
                }
                return Ok(entityToDelete);

              //return await _entityRepo.Get(CNP);
        }
        [HttpPost]
        public async Task<ActionResult<Entity>> PostEntity([FromBody] Entity entity)
        {
            var newEntity = await _entityRepo.Create(entity);
            // return CreatedAtAction(nameof(GetEntities), new {id=newEntity.Id},newEntity);
            return Ok(newEntity);
        }
        [HttpPut]
        public async Task<ActionResult<Entity>> UpdateEntity(string CNP,[FromBody] Entity entity)
        {
            if (CNP != entity.CNP)
            {
                return BadRequest();
            }

            await _entityRepo.Update(entity);

            return NoContent(); 
        }
        [HttpDelete]
        public async Task<ActionResult<Entity>> Delete(int id)
        {
            var entityToDelete = await _entityRepo.Get(id);

            if (entityToDelete == null)
            {
                return NotFound();
            }

            await _entityRepo.Delete(entityToDelete.Id);
            return NoContent();
        }

    }
}

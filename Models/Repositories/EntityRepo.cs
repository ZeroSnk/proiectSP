using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models.Repositories
{
    public class EntityRepo : IEntityRepo
    {
        private readonly EntityContext _entity;
        public EntityRepo(EntityContext entity)
        {
            _entity = entity;
        }
        public async Task<Entity> Create(Entity entity)
        {
            _entity.Entities.Add(entity);
            await _entity.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            var entityToDelete = await _entity.Entities.FindAsync(id);
            _entity.Entities.Remove(entityToDelete);
            await _entity.SaveChangesAsync();
        }

        public async Task<Entity> Get(string CNP)
        {
           return await _entity.Entities.Where(x=>x.CNP == CNP).FirstOrDefaultAsync();
        }
        public async Task<Entity> Get(int id)
        {
            return await _entity.Entities.FindAsync(id);
        }

        public async Task<IEnumerable<Entity>> GetAll()
        {
            return await _entity.Entities.ToListAsync();
        }

        public async Task Update(Entity entity)
        {
            _entity.Entry(entity).State = EntityState.Modified;
            await _entity.SaveChangesAsync();
        }
    }
}

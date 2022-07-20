namespace WebApplication2.Models.Repositories
{
    public interface IEntityRepo
    {
        Task<IEnumerable<Entity>> GetAll();
        Task<Entity> Get(string CNP);
        Task<Entity> Get(int id);
        Task<Entity> Create(Entity entity);
        Task Update(Entity entity);
        Task Delete(int id);
        
    }
}

using Homework2.Domain.Entities;


namespace Homework2.Domain.Repository
{
    public interface IGenericRepository<TEntities> 
        where TEntities : class, IHasId
    {
        //Get all content from whatever entity 
        Task<IEnumerable<TEntities>> GetAllAsync();

        //Get whatever entity by id 
        Task<TEntities?> GetAsync(int id); // I put "?" becuase i don't like acvertence of object null

        //Insert info to entity
        Task PostAsync(TEntities entity);

        //Update whatever entity
        Task UpdateAsync(int id, TEntities entity);

        //Delete info from to entity
        Task<int> DeleteAsync(int id);

    }
}

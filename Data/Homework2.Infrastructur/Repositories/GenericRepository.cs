using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Persistences.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace Homework2.Infrastructur.Repositories
{
    public class GenericRepository<TEntities>: IGenericRepository<TEntities>
        where TEntities: class , IHasId
    {
        public readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Get all content from whatever entity 
        public async Task<IEnumerable<TEntities>> GetAllAsync()
        {
            return await _context.Set<TEntities>().ToListAsync();
        }

        //Get whatever entity by id 
        public async Task<TEntities?> GetAsync(int id) // I put "?" becuase i don't like acvertence of object null
        {
            return await _context.Set<TEntities>().FirstOrDefaultAsync(v => v.Id == id);
        }

        //Insert info to entity
        public async Task PostAsync(TEntities entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();   
        }

        //Update whatever entity
        public async Task UpdateAsync(int id, TEntities entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        //Delete info from to entity
        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Set<TEntities>().Where(e => e.Id == id).ExecuteDeleteAsync();
        }

       
    }
}

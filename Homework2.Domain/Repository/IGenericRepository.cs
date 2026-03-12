using Homework2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

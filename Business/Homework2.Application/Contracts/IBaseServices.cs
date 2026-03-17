using Homework2.Application.Responses;
using Homework2.Domain.Entities;


namespace Homework2.Application.Contracts
{
    public interface IBaseServices<TEntities,TDTO>
        where TEntities: class, IHasId
        where TDTO: class
    {
        Task<ApiResponses<IEnumerable<TDTO>>> GetAllEntityAsync();

        Task<ApiResponses<TDTO>> GetEntityByIdAsync(int id);

        Task<ApiResponses<TDTO>> PostEntityAsync(TEntities entity);

        Task<ApiResponses<TDTO>> UpdateEntityAsync(int id, TEntities entity);

        Task<ApiResponses<TDTO>> DeleteEntityAsync(int id);


    }
}

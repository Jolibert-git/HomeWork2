using Homework2.Domain.Entities;

namespace Homework2.Domain.Repository
{
    public interface IPublisherRepository: IGenericRepository<Publisher>
    {
        //select specific Publishers from specific contry
        Task<List<Publisher>> GetPublishersByCountryAsync(string country);
    }
}

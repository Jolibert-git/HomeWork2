using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Persistences.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Infrastructur.Repositories
{
    public class PublisherRepository: GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext context)
            :base(context)
        {
        }
        //select specific Publishers from specific contry
        public async Task<List<Publisher>> GetPublishersByCountryAsync(string country)
        {
            return await _context.Publishers
                .Where(p => p.Contry.ToLower() == country.ToLower())
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}

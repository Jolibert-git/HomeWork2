
using Homework2.Persistences.DataAccess;
using Homework2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Homework2.Domain.Repository;

namespace Homework2.Infrastructur.Repositories
{
    public class AuthorRepository: GenericRepository<Author>,IAuthorRepository
    {
       
        public AuthorRepository(ApplicationDbContext context)
            :base(context)
        {
        }
        //select Author with him books 
        public async Task<Author?> GetAuthorBooks(int id)
        {
            return await _context.Authors.Include(b => b.Books).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}

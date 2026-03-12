using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Persistences.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Homework2.Infrastructur.Repositories
{
    public class BookRepository: GenericRepository<Book>,IBookRepository
    {
        public BookRepository(ApplicationDbContext context)
            :base(context)
        {
        }
        //select Book with its comments
        public async Task<Book?> BookWithCommentAsync(int id)
        {
            return await _context.Books.Include(c => c.Comments).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}

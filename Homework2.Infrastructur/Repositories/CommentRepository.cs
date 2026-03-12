using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Persistences.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Infrastructur.Repositories
{
    public class CommentRepository: GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context)
            :base(context)
        {
        }
        //select comment with specific word
        public async Task<List<Comment>> SearchInComments(string keyword)
        {
            return await _context.Comments
                .Where(c => c.Body.Contains(keyword))
                .ToListAsync();
        }
    }
}

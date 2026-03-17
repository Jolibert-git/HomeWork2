using Homework2.Domain.Entities;

namespace Homework2.Domain.Repository
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        //select Author with him books 
        Task<Book?> BookWithCommentAsync(int id);
    }
}

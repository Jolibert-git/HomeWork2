using Homework2.Domain.Entities;


namespace Homework2.Domain.Repository
{
    public interface IAuthorRepository: IGenericRepository<Author>
    {
        //select Author with him books 
        Task<Author?> GetAuthorBooks(int id);
    }
}

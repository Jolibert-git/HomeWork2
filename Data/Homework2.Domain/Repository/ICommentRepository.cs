using Homework2.Domain.Entities;


namespace Homework2.Domain.Repository
{
    public interface ICommentRepository: IGenericRepository<Comment>
    {
        //select comment with specific word
        Task<List<Comment>> SearchInComments(string keyword);
    }
}

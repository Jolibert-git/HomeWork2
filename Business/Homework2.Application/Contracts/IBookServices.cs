using Homework2.Application.DTOs.Books;
using Homework2.Application.Responses;


namespace Homework2.Application.Contracts
{
    public interface IBookServices
    {
        Task<ApiResponses<BookWithCommentsDTO>> GetBookWithCommentsAsync(int id);
    }
}

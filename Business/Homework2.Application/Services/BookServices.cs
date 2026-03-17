using AutoMapper;
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Books;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;


namespace Homework2.Application.Services
{
    public class BookServices: BaseServices<Book, BookDTO>, IBookServices
    {
        public BookServices(
                              IMapper mapper,
                              UnitOfWork work,
                              IGenericRepository<Book> repository
                            )
            :base(mapper, work, repository)
        {
        }
   
        public async Task<ApiResponses<BookWithCommentsDTO>> GetBookWithCommentsAsync(int id)
        {
            var book = await _work.Book.BookWithCommentAsync(id); //select Book with its comments

            var bookDTO = _mapper.Map<BookWithCommentsDTO>(book);

            if (bookDTO is null)
                return ApiResponses<BookWithCommentsDTO>.ErrorResponse($"Error with the value's {bookDTO} ");

            return ApiResponses<BookWithCommentsDTO>.SuccessResponse(bookDTO, "Get book with comments successfull");
        }
    }
}

using AutoMapper;
using Homework2.Domain.Entities;
using Homework2.Application.DTOs.Authors;
using Homework2.Application.DTOs.Books;
using Homework2.Application.DTOs.Comments;
using Homework2.Application.DTOs.Loans;
using Homework2.Application.DTOs.MemberUsers;
using Homework2.Application.DTOs.Publishers;

namespace Homework2.Application.Models
{
    public class MapperProfile:Profile
    {
        
        public MapperProfile()
        {
            CreateMap<Author, AuthorDTO>().
                                           ForMember(dto => dto.FullName,comfig => comfig.
                                           MapFrom(author => $"{author.Name} {author.LastName}")).ReverseMap();

            CreateMap<Loan, LoanDTO>();

            CreateMap<Book, BookDTO>();

            CreateMap<MemberUser, MemberUserDTO>();

            CreateMap<Publisher, PublisherDTO>();

            //CreateMap<Author, AuthorDTO>().ReverseMap();

            CreateMap<Comment, CommentDTO>().ReverseMap();

            CreateMap<CommentDTO, CommentBodyDTO>().ReverseMap();

            CreateMap<Author, AuthorPatchDTO>().ReverseMap();

            CreateMap<Author, AuthorWithBooksDTO>();

            CreateMap<Book, BookWithCommentsDTO>();

            CreateMap<Comment, BodyCommentDTO>();

            CreateMap<Book,TitleBookDTO>();

        }

        
    }
}

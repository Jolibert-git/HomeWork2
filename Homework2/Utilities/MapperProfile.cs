using AutoMapper;
using Homework2.DTOs;
using Homework2.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Homework2.Utilities
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

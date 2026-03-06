using AutoMapper;
using Homework2.DTOs;
using Homework2.Entities;

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

            CreateMap<CommentDTO, CommentPatchDTO>().ReverseMap();

            CreateMap<Author, AuthorPatchDTO>().ReverseMap();


        }

        
    }
}

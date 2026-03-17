using AutoMapper;
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Publishers;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;


namespace Homework2.Application.Services
{
    public class PublisherServices: BaseServices<Publisher,PublisherDTO>, IPublisherServices
    {
        public PublisherServices(
                              IMapper mapper,
                              UnitOfWork work,
                              IGenericRepository<Publisher> repository
                              )
            : base(mapper, work, repository)
        {
        }

        public async Task<ApiResponses<List<PublisherDTO>>> GetPublishersByCountryAsync(string contry)
        {
            var publisher = await _work.Publisher.GetPublishersByCountryAsync(contry);//select specific Publishers from specific contry

            if (publisher is null) 
                return ApiResponses<List<PublisherDTO>>.ErrorResponse("There aren't publisher from that contry");//400

            var pubisherDTO = _mapper.Map<List<PublisherDTO>>(publisher);

            return ApiResponses<List<PublisherDTO>>.SuccessResponse( pubisherDTO, " Get Publisher by Contry Successfull");//200
        }
    }
}

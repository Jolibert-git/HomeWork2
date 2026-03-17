using Homework2.Application.DTOs.Publishers;
using Homework2.Application.Responses;


namespace Homework2.Application.Contracts
{
    public interface IPublisherServices
    {
        Task<ApiResponses<List<PublisherDTO>>> GetPublishersByCountryAsync(string contry);
    }
}

using Homework2.Application.DTOs.MemberUsers;
using Homework2.Application.Responses;


namespace Homework2.Application.Contracts
{
    public interface IMemberUserServices
    {
        Task<ApiResponses<List<MemberUserDTO>>> GetActiveMembersAsync();
    }
}

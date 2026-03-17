using AutoMapper;
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.MemberUsers;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;


namespace Homework2.Application.Services
{
    public class MemberUserServices: BaseServices<MemberUser, MemberUserDTO>, IMemberUserServices
    {
        public MemberUserServices(
                              IMapper mapper,
                              UnitOfWork work,
                              IGenericRepository<MemberUser> repository
                              )
            : base(mapper, work, repository)
        {
        }

        public async Task<ApiResponses<List<MemberUserDTO>>> GetActiveMembersAsync()
        {
            var active = await _work.MemberUser.GetActiveMembersAsync();//select MemberUser that are active

            if (active is null) 
                return ApiResponses<List<MemberUserDTO>>.ErrorResponse("There aren't User active");

            var activeDTO = _mapper.Map<List<MemberUserDTO>>(active);

            return ApiResponses<List<MemberUserDTO>>.SuccessResponse(activeDTO,"Get MemberUser Active Successfull");
        }
    }
}

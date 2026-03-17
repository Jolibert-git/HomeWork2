using Homework2.Domain.Entities;


namespace Homework2.Domain.Repository
{
    public interface IMemberUserRepository: IGenericRepository<MemberUser>
    {
        //select MemberUser that are active
        Task<List<MemberUser>> GetActiveMembersAsync();
    }
}

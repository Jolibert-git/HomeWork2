using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Persistences.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Infrastructur.Repositories
{
    public class MemberUserRepository: GenericRepository<MemberUser>, IMemberUserRepository
    {
        public MemberUserRepository(ApplicationDbContext context)
            :base(context)
        {
        }
        //select MemberUser that are active
        public async Task<List<MemberUser>> GetActiveMembersAsync()
        {
            return await _context.MemberUsers
                .Where(u => u.IsActive)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }
    }
}

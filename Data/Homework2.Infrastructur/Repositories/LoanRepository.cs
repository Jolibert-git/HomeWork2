using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Persistences.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Infrastructur.Repositories
{
    public class LoanRepository: GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationDbContext context)
            :base(context)
        {
        }
        //select Loan with specific User
        public async Task<List<Loan>> GetLoansByUserIdAsync(int userId)
        {
            return await _context.Loans
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.LoanDate)
                .ToListAsync();
        }
    }
}

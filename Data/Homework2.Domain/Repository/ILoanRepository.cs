using Homework2.Domain.Entities;


namespace Homework2.Domain.Repository
{
    public interface ILoanRepository: IGenericRepository<Loan>
    {
        //select Loan with specific User
        Task<List<Loan>> GetLoansByUserIdAsync(int userId);
    }
}

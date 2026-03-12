using Homework2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Domain.Repository
{
    public interface ILoanRepository: IGenericRepository<Loan>
    {
        //select Loan with specific User
        Task<List<Loan>> GetLoansByUserIdAsync(int userId);
    }
}

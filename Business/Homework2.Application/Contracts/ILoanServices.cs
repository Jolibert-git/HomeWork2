using Homework2.Application.DTOs.Loans;
using Homework2.Application.Responses;


namespace Homework2.Application.Contracts
{
    public interface ILoanServices
    {
        Task<ApiResponses<List<LoanDTO>>> GetLoanByUser(int id);
    }
}

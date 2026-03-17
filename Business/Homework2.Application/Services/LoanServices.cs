using AutoMapper;
using Homework2.Application.Contracts;
using Homework2.Application.DTOs.Loans;
using Homework2.Application.Responses;
using Homework2.Domain.Entities;
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;


namespace Homework2.Application.Services
{
    public class LoanServices: BaseServices<Loan,LoanDTO>, ILoanServices
    {
        public LoanServices(
                              IMapper mapper,
                              UnitOfWork work,
                              IGenericRepository<Loan> repository
                            )
            :base(mapper, work, repository)
        {
        }

        public async Task<ApiResponses<List<LoanDTO>>> GetLoanByUser(int id)
        {
            var loan = await _work.Loan.GetLoansByUserIdAsync(id);  //select Loan with specific User
            var loanDTO = _mapper.Map<List<LoanDTO>>(loan);

            if (loanDTO is null) 
                return ApiResponses<List<LoanDTO>>.ErrorResponse("Proble With Loan");//404


            return ApiResponses<List<LoanDTO>>.SuccessResponse(loanDTO, " Get Loan Successfull ");//200
        }

    }
}

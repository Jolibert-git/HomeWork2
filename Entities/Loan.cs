using System.ComponentModel.DataAnnotations;

namespace Homework2.Entities
{
    public class Loan
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "You need User for that accion")]
        public required MemberUser User { set; get; }
        public int BookId { set; get; }
        public DateTime? LoanDate { set; get; }
        public DateTime? DueDate { set; get; }
        public DateTime? ReturnDate { set; get; }
        public decimal? RentalPrice { set; get; }
        public decimal ReturnLate { set; get; }
        public decimal TotalAmount { set; get; }
        public LoanStatus Status { set; get; }

    }
    public enum LoanStatus
    {
        Pending = 1,
        Returned = 2,
        Overdue = 3,
        Renewed = 4,
        Lost = 5
    }

}

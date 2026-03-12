using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework2.Domain.Entities
{
    public class Loan: IHasId
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "You need UserId for that accion")]
        public int UserId { set; get; }
        //public required MemberUser User { set; get; }
        public int BookId { set; get; }
        public DateTime? LoanDate { set; get; }
        public DateTime? DueDate { set; get; }
        public DateTime? ReturnDate { set; get; }
        [Column(TypeName = "decimal(18,2)")] //I used that because i wanted Migrated a new data base different manual database 
        public decimal? RentalPrice { set; get; }
        [Column(TypeName = "decimal(18,2)")] //I used that because i wanted Migrated a new data base different manual database
        public decimal ReturnLate { set; get; }
        [Column(TypeName = "decimal(18,2)")] //I used that because i wanted Migrated a new data base different manual database
        public decimal TotalAmount { set; get; }
        public LoanStatus Status { set; get; }

    }
    public enum LoanStatus// It's limiter i prefer use enum instead of create class when is limiter contain
    {
        Pending = 1,
        Returned = 2,
        Overdue = 3,
        Renewed = 4,
        Lost = 5
    }

}

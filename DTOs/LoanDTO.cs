namespace Homework2.DTOs
{
    public class LoanDTO
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public int BookId { set; get; }
        public DateTime? LoanDate { set; get; }
        public DateTime? ReturnDate { set; get; }
        public decimal TotalAmount { set; get; }
    }
}

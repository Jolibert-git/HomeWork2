using Homework2.Entities;

namespace Homework2.DTOs
{
    public class CommentDTO
    {
        public int Id { set; get; }
        public string Body { set; get; } = string.Empty;
        public DateTime Date { set; get; }
        public int BookId { set; get; }
        public Book? Book { set; get; }
    }
}

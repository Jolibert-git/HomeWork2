using System.ComponentModel.DataAnnotations;

namespace Homework2.Domain.Entities
{
    public class Comment: IHasId
    {
        public int Id { set; get; }
        [StringLength(200, ErrorMessage = "The name need stay in range to 200")]
        public string Body { set; get; } = string.Empty;
        public DateTime Date { set; get; } = DateTime.Now; 
        public int BookId { set; get; }
        public Book? Book { set; get; }
    }
}

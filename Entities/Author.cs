using System.ComponentModel.DataAnnotations;

namespace Homework2.Entities
{
    public class Author
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "You need Name")]
        public string Name { set; get; } = string.Empty;
        [Required(ErrorMessage = "You need LastName")]
        public string LastName { set; get; } = string.Empty;
        public DateTime Age { set; get; } = DateTime.Now;
        public string natinolity { set; get; } = string.Empty;
        public List<Book> Books { set; get; } = new List<Book>();
    }
}

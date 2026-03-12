using System.ComponentModel.DataAnnotations;

namespace Homework2.Domain.Entities
{
    public class Author: IHasId
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "You need Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name need saty between 3 to 20")]
        public string Name { set; get; } = string.Empty;
        [Required(ErrorMessage = "You need LastName")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The lastname need saty between 3 to 20")]
        public string LastName { set; get; } = string.Empty;
        public DateTime Age { set; get; } = DateTime.Now;
        [StringLength(35, ErrorMessage = "The nationality need stay in range 35")]
        public string natinolity { set; get; } = string.Empty;
        public List<Book> Books { set; get; } = new List<Book>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace Homework2.Entities
{
    public class Publisher
    {
        public int Id { set; get; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Name Need stay between 3 and 100")]
        public string Name { set; get; }= string.Empty;
        public string Contry { set; get; } = string.Empty;
    }
}

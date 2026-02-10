using System.ComponentModel.DataAnnotations;

namespace Homework2.Entities
{
    public class MemberUser
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "You need Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Name Need stay between 3 and 100")]
        public required string Name { set; get; } = string.Empty;
        [Required(ErrorMessage = "You need LastName")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The LastName Need stay between 3 and 100")]
        public string LastName { set; get; } = string.Empty;
        public DateTime Age  { set; get; }
        public string PhoneNumber { set; get; } = string.Empty;
        public string Email { set; get; } = string.Empty;
        public string Location { set; get; } = string.Empty;
        public bool IsActive { set; get; } 
    }
}

//using Homework2.Validation;
using System.ComponentModel.DataAnnotations;

namespace Homework2.Domain.Entities
{
    public class Publisher: IHasId
    {
        public int Id { set; get; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Name Need stay between 3 and 100")]
        public string Name { set; get; }= string.Empty;
        //[FirstCapitalLetterAttribute]
        public string Contry { set; get; } = string.Empty;
    }
}

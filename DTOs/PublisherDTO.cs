using Homework2.Validation;
using System.ComponentModel.DataAnnotations;

namespace Homework2.DTOs
{
    public class PublisherDTO
    {
        public int Id { set; get; }
        public string Name { set; get; } = string.Empty;
        public string Contry { set; get; } = string.Empty;
    }
}

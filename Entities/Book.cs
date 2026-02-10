using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Security.Principal;

namespace Homework2.Entities
{
    public class Book
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "The Title is mandatory")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Title Need stay between 1 and 100")]
        public string Title { set; get; }
        public DateTime PublicationYear { set; get; }
        public short NumberPage { set; get; }
        public  BookCategory Category { set; get; }
        public string Publisher { set; get; } = string.Empty;
        public FisicStatus Status { set; get; }
        public int? WriterId { get; set; }
        [ForeignKey("WriterId")]
        public Author? Writer { get; set; } 
        public bool IsActive { set; get; }
    }
    public enum BookCategory
    {
        Fiction = 1,
        NonFiction = 2,
        Fantasy = 3,
        Mystery = 4,
        ScienceFiction = 5
    }

    public enum FisicStatus
    {
        New = 1,
        Good = 2,
        Fair = 3,
        Demaged = 4,
    }
}

using Homework2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Persistences.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { set; get; }
        public DbSet<Book> Books { set; get; }
        public DbSet<Loan> Loans { set; get; }
        public DbSet<MemberUser> MemberUsers { set; get; }
        public DbSet<Publisher> Publishers { set; get; }
        public DbSet<Comment> Comments { set; get; }
    }
}

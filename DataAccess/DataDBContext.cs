using Homework2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homework2.DataAccess
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { set; get; }
        public DbSet<Book> Books { set; get; }
        public DbSet<Loan> Loans { set; get; }
        public DbSet<MemberUser> MemberUsers { set; get; }
        public DbSet<Publisher> Publishers { set; get; }
    }
}

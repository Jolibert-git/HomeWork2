using Homework2.Domain.Repository;
using Homework2.Persistences.DataAccess;

namespace Homework2.Infrastructur.Repositories
{
    public class UnitOfWork
    {
        public ApplicationDbContext _context { get; }
        public IAuthorRepository Author { get; }
        public IBookRepository Book { get; }
        public ICommentRepository Comment { get; }
        public ILoanRepository Loan { get; }
        public IMemberUserRepository MemberUser { get; }
        public IPublisherRepository Publisher { get; }

        public UnitOfWork(ApplicationDbContext contex, 
                          IAuthorRepository authorRepository, 
                          IBookRepository bookRepository, 
                          ICommentRepository commentRepository, 
                          ILoanRepository loanRepository, 
                          IMemberUserRepository memberUserRepository, 
                          IPublisherRepository publisherRepository)
        {
            this._context = contex;
            this.Author = authorRepository;
            this.Book = bookRepository;
            this.Comment = commentRepository;
            this.Loan = loanRepository;
            this.MemberUser = memberUserRepository;
            this.Publisher = publisherRepository;
        }

        public async Task Complite()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BegingTransation()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task RollbackTrasaction()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _context.Database.CommitTransactionAsync();
        }


    }
}

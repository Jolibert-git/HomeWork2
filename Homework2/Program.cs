
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;
using Homework2.Infrastructur.Repository;
using Homework2.MidleWare;
using Homework2.Persistences.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Homework2
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);


            // I don't use Swegger because I usually use Postman

            //services
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookRepository,BookRepository>();
            builder.Services.AddScoped<ICommentRepository,CommentRepository>();
            builder.Services.AddScoped<ILoanRepository,LoanRepository>();
            builder.Services.AddScoped<IMemberUserRepository,MemberUserRepository>();
            builder.Services.AddScoped<IPublisherRepository,PublisherRepository>();
            builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddScoped(typeof(GenericRepository<>));

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(opcion => opcion.UseSqlServer("name = ConnectionDefault"));

            builder.Services.AddControllers().AddNewtonsoftJson();

            var app = builder.Build();

            //zone MidleWares

            //app.UseLoggerRequest();

            //app.UseLoggerAccess();

            //Controller
            app.MapControllers();

            app.Run();
        }
    }
}

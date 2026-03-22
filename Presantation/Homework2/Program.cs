
using Homework2.Application.Contracts;
using Homework2.Application.Services;
using Homework2.Domain.Repository;
using Homework2.Infrastructur.Repositories;
//using Homework2.Infrastructur.Repository;
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
            builder.Services.AddAutoMapper(typeof(Homework2.Application.Models.MapperProfile));

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookRepository,BookRepository>();
            builder.Services.AddScoped<ICommentRepository,CommentRepository>();
            builder.Services.AddScoped<ILoanRepository,LoanRepository>();
            builder.Services.AddScoped<IMemberUserRepository,MemberUserRepository>();
            builder.Services.AddScoped<IPublisherRepository,PublisherRepository>();
            builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            builder.Services.AddScoped(typeof(IBaseServices<,>), typeof(BaseServices<,>));
            //builder.Services.AddScoped(typeof(IBaseServices<,>), typeof(BaseServices<,>));
            builder.Services.AddScoped<IAuthorServices, AuthorServices>();
            builder.Services.AddScoped<IBookServices, BookServices>();
            builder.Services.AddScoped<ICommentServices, CommentsServices>();
            builder.Services.AddScoped<ILoanServices, LoanServices>();
            builder.Services.AddScoped<IMemberUserServices, MemberUserServices>();
            builder.Services.AddScoped<IPublisherServices, PublisherServices>();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(opcion => opcion.UseSqlServer("name = ConnectionDefault"));

            builder.Services.AddControllers().AddNewtonsoftJson();

            var app = builder.Build();

            //zone MidleWares

            app.UseLoggerRequest();

            app.UseLoggerAccess();

            //Controller
            app.MapControllers();

            app.Run();
        }
    }
}

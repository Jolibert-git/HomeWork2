
using Homework2.DataAccess;
using Homework2.MidleWare;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

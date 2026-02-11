
using Homework2.DataAccess;
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
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataDbContext>(opcion => opcion.UseSqlServer("name = ConnectionDefault"));
 
            var app = builder.Build();

            //Controller
            app.MapControllers();

            app.Run();
        }
    }
}

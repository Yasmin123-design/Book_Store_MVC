using BOOKS_.Models;
using BOOKS_.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace BOOKS_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BookContext>(builderoption =>
            builderoption.UseSqlServer("Server=DESKTOP-I7PU4G3;Database=Library;Trusted_Connection=True;Encrypt=false"));
			builder.Services.AddScoped<IBookRepository, BookRepositor>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IBookDetailsRepository,BookDetailsRepository>();
			builder.Services.AddScoped<IReaderRepository, ReaderRepository>();
			builder.Services.AddScoped<IBookReaderRepository, BookReaderRepository>();
			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

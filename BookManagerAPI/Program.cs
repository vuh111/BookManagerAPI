using AutoMapper;
using BookManagerBUS.AuthorBusiness;
using BookManagerBUS.BookBusiness;
using BookManagerBUS.CategoryBusiness;
using BookManagerBUS.RequestModel;
using BookManagerDAL;
using BookManagerDAL.Model;

namespace BookManagerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<BookManagerDbcontext>();

            builder.Services.AddTransient<IBookRepository,BookRepository>();
            builder.Services.AddTransient<IBookService,BookService>();
            builder.Services.AddTransient<IAutherService,AuthorService>();
            builder.Services.AddTransient<IAuthorRepository,AuthorRepository>();
            builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
            builder.Services.AddTransient<ICategoryService,CategoryService>();





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
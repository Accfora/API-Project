using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using BusinessLogic.Services;
using DataAccess;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FirstSaturday
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LContext>(o => o.UseSqlServer("Server=DESKTOP-OKU7E5D;Database=L;Integrated Security=True"));
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IGoodService, GoodService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderContentService, OrderContentService>();
            builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IFilterService, FilterService>();
            builder.Services.AddScoped<IGoodFilterValueService, GoodFilterValueService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Интернет-магазин SaturdayAPI",
                    Description = "Интернет-магазин выходного дня, в котором собраны различные товары для жизни",
                    Contact = new OpenApiContact
                    {
                        Name = "Контакты: Леонид Бородин",
                        Url = new Uri("https://vk.com/qwerty729")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

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
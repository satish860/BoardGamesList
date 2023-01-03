using BoardGamesListAPI.Database;
using BoardGamesListAPI.Domain;
using BoardGamesListAPI.Validators;
using Marten;

namespace BoardGamesListAPI
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
            builder.Services.AddSwaggerGen(option =>
            {
                option.ParameterFilter<SortColumnValidatorFilter>();
            });
            builder.Services.AddMarten(opt =>
            {
                opt.Connection(builder.Configuration.GetConnectionString("postgres"));
                opt.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
                opt.RegisterDocumentType<BoardGames>();
            }).InitializeWith(new SeedData(new CsvParser(), "Data/bgg_dataset.csv"));

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
using dynamic_json.JsonProcessors;

namespace dynamic_json;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IJsonProcessor, UserJsonProcessor>();
        builder.Services.AddSingleton<IJsonProcessor, ProductJsonProcessor>();
        builder.Services.AddSingleton<IJsonProcessor, TodoItemProcessor>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        // Redirect root URL to Swagger UI
        app.MapGet("/", () => Results.Redirect("/swagger"));

        app.MapControllers();

        app.Run();
    }
}
namespace WeatherAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();
            builder.Services.AddDAL(builder.Configuration);
            builder.Services.AddBLL();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowFrontend");

            using var scope = app.Services.CreateScope();
            var dataIntializer = scope.ServiceProvider.GetRequiredService<DataSeeder>();
            await dataIntializer.Initialize();

            app.UseMiddleware<ExceptionHandler>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
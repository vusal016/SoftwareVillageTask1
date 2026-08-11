namespace WeatherAPI.Swagger
{
    public static class SwaggerConfigurations
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var xmlFile =
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlPath =
                    Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
                options.OperationFilter<WeatherResponseExampleFilter>();
            });
            return services;
        }
        public static WebApplication UseSwaggerDocumentation(this WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API V1");
                options.RoutePrefix = "docs";
            });
            return app;
        }
    }
}
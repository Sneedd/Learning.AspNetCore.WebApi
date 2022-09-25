
using Learning.AspNetCore.WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;

        // --------------------------------------------------------------------------------------------

        services.AddOptions();
        services.Configure<DatabaseOptions>(builder.Configuration.GetSection("Database"));

        services.AddControllers(options =>
        {
            options.Filters.Add(new ApiControllerAttribute());
            //options.Filters.Add(new AuthorizeFilter());
        });

        services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.Authority = "";
            });
        services.AddAuthorization(options =>
        {
            options.AddPolicy("default", policy =>
            {
                policy.RequireAuthenticatedUser();
            });
            options.AddPolicy("admin", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("role", "admin");
            });
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<SiteContext>();

        // --------------------------------------------------------------------------------------------

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler("/api/error");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
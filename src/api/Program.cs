
using Microsoft.Net.Http.Headers;

namespace tutsica;

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

        // In production, the React files will be served from this directory
        builder.Services.AddSpaStaticFiles(c => { c.RootPath = "spa"; });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseSpaStaticFiles();
        app.UseAuthorization();

        app.MapControllers();

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "../app";
            if (app.Environment.IsDevelopment())
                spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
        });

        app.Run();
    }
}

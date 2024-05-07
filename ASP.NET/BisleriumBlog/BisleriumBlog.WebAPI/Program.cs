using BisleriumBlog.WebAPI.Helper;
using BisleriumBlog.Infrastructure.DI;
using Microsoft.Extensions.FileProviders;

namespace BisleriumBlog.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddSignalR();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddSignalR();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.AddAuthentication();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(opions =>
            {
                opions.AddPolicy("frontend", policyBuilder =>
                {
                    policyBuilder.WithOrigins("https://localhost:7243/");
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.AllowCredentials();
                });
            });

            var app = builder.Build();
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "BlogImages")),
                    RequestPath = "/Images/BlogImages"
                });
            }

           /* app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());*/

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            // Add 
            //app.UseEndpoints(endpoints => endpoints.MapHub<Notification>("/notification"));
            app.MapHub<Notification>("/notification");

            app.MapControllers();

            app.UseCors("frontend");

            app.Run();
        }
    }
}

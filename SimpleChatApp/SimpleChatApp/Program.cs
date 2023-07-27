using SimpleChatApp.Handler;
using SimpleChatApp.Hubs;

namespace SimpleChatApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<ChatHandler>();

            builder.Services.AddSignalR();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            

            app.UseHttpsRedirection();
            app.UseRouting();

            // Cors Policy
            app.UseCors(options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowCredentials().AllowAnyHeader());
            app.UseAuthorization();
     
           
            app.MapControllers();

            // chathub endpoint
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chathub");
            });

            app.Run();
        }
    }
}

namespace Credentials
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                    policy  =>
                    {
                        policy.WithOrigins(["http://localhost:5068"])
                            .AllowCredentials()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyAllowSpecificOrigins");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

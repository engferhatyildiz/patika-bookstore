using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using patika_bookstore.DBOperations;

namespace patika_bookstore;


public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration = configuration;


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Patika.Bookstore", Version = "v1" }); });
        services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patika.Cohorts v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
using club.van.api.business.Implementacao;
using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.dao.Implementacao;
using club.van.api.dao.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace club.van.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Club Van API", Version = "v1" });
            });

            services.AddScoped<ClubVanContext, ClubVanContext>();

            services.AddTransient<IUsuarioBusiness, UsuarioBusiness>();
            services.AddTransient<IUsuarioDao, UsuarioDao>();
            services.AddTransient<IEmpresaDao, EmpresaDao>();
            services.AddTransient<IPerfilDao, PerfilDao>();
            services.AddTransient<IRotaDao, RotaDao>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Club Van API - V1");
            });

            loggerFactory.AddFile("Logs/club-van-api-(Date).txt");
        }


    }
}

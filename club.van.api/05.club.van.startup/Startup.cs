using club.van.api.business.Implementacao;
using club.van.api.business.Interface;
using club.van.api.dao.EF;
using club.van.api.dao.Implementacao;
using club.van.api.dao.Interface;
using club.van.dao.Implementacao;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace club.van.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers()
                     .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Club Van API", Version = "v1" });
            });

            services.AddScoped<ClubVanContext, ClubVanContext>();

            services.AddSingleton<IConfiguration>(Configuration);

            //Usuario
            services.AddTransient<IUsuarioBusiness, UsuarioBusiness>();
            services.AddTransient<IUsuarioDao, UsuarioDao>();

            //Empresa
            services.AddTransient<IEmpresaDao, EmpresaDao>();

            //Perfil
            services.AddTransient<IPerfilBusiness, PerfilBusiness>();
            services.AddTransient<IPerfilDao, PerfilDao>();

            //Rota
            services.AddTransient<IRotaBusiness, RotaBusiness>();
            services.AddTransient<IRotaDao, RotaDao>();

            //Veiculo
            services.AddTransient<IVeiculoBusiness, VeiculoBusiness>();
            services.AddTransient<IVeiculoDao, VeiculoDao>();

            //ViagemDias
            services.AddTransient<IViagemDiasBusiness, ViagemDiasBusiness>();
            services.AddTransient<IViagemDiasDao, ViagemDiasDao>();


            // JWT
            var key = Encoding.ASCII.GetBytes(Configuration["AppSettings:Secret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["AppSettings:ValidoEm"],
                    ValidIssuer = Configuration["AppSettings:Emissor"]
                };
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options =>
            options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthentication();

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

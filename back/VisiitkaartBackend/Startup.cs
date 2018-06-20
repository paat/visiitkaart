using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VisiitkaartBackend.Data;
using VisiitkaartBackend.Services;
using VisiitkaartBackend.Services.Interfaces;
using VisiitkaartBackend.Services.Repositories;
using VisiitkaartBackend.Services.Repositories.Interfaces;

namespace VisiitkaartBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(CorsOptions);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtOptions);
            services.AddDbContext<VisiitkaartDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Visiitkaart"))
                );
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomSignInService, CustomSignInService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseMvc();
        }

        private static void CorsOptions(CorsOptions options)
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials()
            .Build());
        }

        private void JwtOptions(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API01.Etec.Data;
using API01.Etec.Service;
using API01.Etec.Interfaces.Service;
using API01.Etec.Repository;
using API01.Etec.Interfaces.Repository;

namespace API01.Etec
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", config =>
                     config.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           // .AllowCredentials()
                           .Build()
                );
            });

            services.AddDbContext<API01EtecContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("API01EtecContext")));

            #region InjecaoDeDependencia
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            #endregion

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1",
                   new Microsoft.OpenApi.Models.OpenApiInfo()
                   {
                       Title = "Primeira api do curso Desenvolvimento Etec",
                       Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                       {
                           Email = "marcio.nizzola@etec.sp.gov.br",
                           Name = "Marcio R Nizzola",
                           Url = new Uri("http://www.etecitu.com.br")
                       },
                       Description = "Esta api é um teste"
                   });
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Primeira Api ");
            });
        }
    }
}

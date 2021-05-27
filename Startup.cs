using FluentValidation.AspNetCore;
using HairdressingStudio.DatabaseContext;
using HairdressingStudio.Services;
using HairdressingStudio.Services.Interfaces;
using HairdressingStudio.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HairdressingStudio
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
            //Dodanie obs�ugi Entity FrameWork zwi�zanej z SqlServer.
            services.AddEntityFrameworkSqlServer();
            //Dodanie HairdressingStudioContext.
            services.AddDbContext<HairdressingStudioContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
         
            // Poni�sza konfiguracja jest bazowa i niezwykle prosta
            // AllowAnyOrigin() - mo�e zosta� zmienione na np. WithOrigings("http://www.naszezrodlo.com") - dost�p tylko z tego miejsca
            // AllowAnyMethod() - mo�emy zezwoli� na dost�p do wybranych metod np. WithMethods("POST", "GET")
            // AllowAnyHeader() - mo�emy akceptowa� jedynie wybrane nag��wki, np. WithHeaders("accept", "content-type")
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HairdressingStudioApi", Version = "v1" });
            });
            services.AddControllers();

            services.AddScoped<IStylistsData, StylistsData>();
            services.AddScoped<IHairdressingServicesData, HairdressingServicesData>();
            services.AddScoped<IStylistsWorkingHoursData, StylistsWorkingHoursData>();
            services.AddScoped<IListOfAvailableDates, ListOfAvailableDates>();
            services.AddScoped<IClientsData, ClientsData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                // middleware kt�ry doda Swagger JSON
                app.UseSwagger();
                // middleware do swagger-ui (HTML, JS, CSS, etc.),
                // tutaj okre�lasz endpoint dla Swagger JSON
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HairdressingStudioApi v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Nazwa u�ywanej polityki zosta�a zdefiniowana w metodzie ConfigureServices(...)
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

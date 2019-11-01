using Api.MeetingRoom.Business;
using Api.MeetingRoom.Repository;
using Api.MeetingRoom.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Api.MeetingRoom.Business.Interface;
using System.IO;
using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using Api.MeetingRoom.Repository.Context;

namespace Api.MeetingRoom
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMeetingRoomSchedulingRepository, MeetingRoomSchedulingRepository>();
            services.AddScoped<IMeetingRoomRepository, MeetingRoomRepository>();

            services.AddScoped<IMeetingRoomBusiness, MeetingRoomBusiness>();
            services.AddScoped<IMeetingRoomSchedulingBusiness, MeetingRoomSchedulingBusiness>();

            var connectionString = "Server=localhost;Database=meeting_room;Uid=root;Pwd=Lucas!@12QWqw;";
            services.AddDbContext<MeetingRoomContext>(options => options.UseMySql(connectionString));
            services.AddDbContext<MeetingRoomSchedulingContext>(options => options.UseMySql(connectionString));

            services.AddControllers();
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Meeting-Room V1", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="serviceProvider"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors("MyPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Meeting-Room V1");
                c.RoutePrefix = "docs";
            });

            DatabasePopulation.IncludeData(serviceProvider);

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
        }
    }
}

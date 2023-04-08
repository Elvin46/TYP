using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TYP.Core;
using TYP.Data;
using TYP.Service.Profiles;
using TYP.Service.Services.Implementations;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC
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
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddResponseCaching();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherPredmetService, TeacherPredmetService>();
            services.AddScoped<IScientificDegreeService, ScientificDegreeService>();
            services.AddScoped<IScientificNameService, ScientificNameService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IJobTypeService, JobTypeService>();
            services.AddScoped<IScientificDegreeService, ScientificDegreeService>();
            services.AddScoped<IPredmetService, PredmetService>();
            services.AddScoped<IPredmetProfessionService, PredmetProfessionService>();
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<IGroupService, GroupService>();

            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Teacher}/{action=Index}/{id?}");
            });
        }
    }
}

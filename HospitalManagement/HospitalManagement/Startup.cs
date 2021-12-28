using FluentValidation.AspNetCore;
using HospitalManagement.Context;
using HospitalManagement.Models;
using HospitalManagement.Repositories;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement
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
            services.AddControllers()
                 .AddFluentValidation(s =>
                 {
                     s.RegisterValidatorsFromAssemblyContaining<Startup>();
                     s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                 });
            services.AddDbContext<MedicalManageMentContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("SqlConnection")));
            services.AddAutoMapper(typeof(Startup));
            // services.AddScoped<ExaminationGroupReception>();
            //services.AddTransient<IPatientRepository, PatientRepository>();
            //services.AddDbContext() < MedicalManagementContext > (
            //    options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IExaminationRepository, ExaminationRepository>();
            services.AddTransient<IReceptionRepository, ReceptionRepository>();
            services.AddTransient<IReceptionExaminationRepository, ReceptionExaminationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalManagement", Version = "v1" });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManagement v1"));
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

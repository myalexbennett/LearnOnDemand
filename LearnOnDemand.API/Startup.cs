using LearnOnDemand.Entities;
using LearnOnDemand.Interfaces;
using LearnOnDemand.Repositories;
using LearnOnDemand.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnOnDemand.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<ISendGridService, SendGridService>(client => new SendGridService(Configuration["HTTP:SendGripAPIUrl"]));
            services.AddDbContext<LearnOnDemandContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LearnOnDemandDatabase")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Core.Interface.Repository;
using Account.Application.Core.Interface.Service;
using Account.Application.Core.Service;
using Account.Infraestructure.Data;
using Account.Infraestructure.Repository;
using Account.Infraestructure.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Account.Web.Api
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
            services.Configure<DbUsersConectionSettings>(
                    Configuration.GetSection(nameof(DbUsersConectionSettings)));

            services.AddSingleton<IMongoConfigurationSettings>(sp =>
            sp.GetRequiredService<IOptions<DbUsersConectionSettings>>().Value);

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

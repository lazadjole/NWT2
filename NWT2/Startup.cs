using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NWT2.Filters;
using NWT2.Models;

namespace NWT2
{
    public class Startup
    {
        private readonly int _httpsPort = 44319;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(opt => opt.LowercaseUrls = true);
            services.AddMvc(opt =>
            {
                opt.SslPort = _httpsPort;
                opt.Filters.Add(typeof(JsonExceptionFilters));
                opt.Filters.Add(typeof(RequireHttpsAttribute));
            }
         );

            services.AddDbContext<PicerijaDbContext>(opt => opt.UseSqlServer("Server=DESKTOP-R5NN8B8\\SQLEXPRESS;Database=Picerija;Integrated Security=true"));

            services.AddControllers()
                 .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

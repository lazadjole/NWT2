using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using NWT2.Infrastructure;
using NWT2.Models;
using NWT2.Services;

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
            services.AddRouting(opt => opt.LowercaseUrls = true);
            services.AddMvc(opt =>
            {
                opt.SslPort = _httpsPort;
                opt.Filters.Add(typeof(JsonExceptionFilters));
                opt.Filters.Add(typeof(RequireHttpsAttribute));
                opt.Filters.Add(typeof(LinkRewritingFilter));
            }
         );

            services.AddDbContext<PicerijaDbContext>(opt => opt.UseSqlServer("Server=DESKTOP-R5NN8B8\\SQLEXPRESS;Database=Picerija;Integrated Security=true"));
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers()
                 .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddScoped<IAdresaService, AdresaService>();
            services.AddScoped<IDetaljiNarudzbeniceService, DetaljiNarudzbeniceService>();
            services.AddScoped<IEkstraDodaciService, EkstraDodaciService>();
            services.AddScoped<IDodatakService, DodatakService>();
            services.AddScoped<IkupacService, KupacService>();
            services.AddScoped<INarudzbenicaService, NarudzbenicaService>();
            services.AddScoped<IPicaService, PicaService>();
            services.AddScoped<IStatusDostaveService, StatusDostaveService>();
            services.AddScoped<ITipVozilaService, TipVozilaService>();
            services.AddScoped<IVoziloService, VoziloService>();
            services.AddScoped<IZaposleniService, ZaposleniService>();
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

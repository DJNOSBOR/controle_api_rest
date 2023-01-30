using Controle.Api.Services;
using Controle.Data.Context;
using Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Controle.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen();

            services.AddScoped<IAssemblyResolver, AssemblyResolver>();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ControleDbContext>(options =>
                                            options.UseNpgsql(connectionString));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSelfBindableInterfacesBindings(typeof(ProdutoService));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            app.UseSwagger();
            app.UseSwaggerUI();

        }
    }
}

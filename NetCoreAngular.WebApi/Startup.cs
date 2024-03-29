using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreAngular.BussinessLogic.Implementations;
using NetCoreAngular.BussinessLogic.Interfaces;
using NetCoreAngular.DataAccess;
using NetCoreAngular.UnitOfWork;
using NetCoreAngular.WebApi.Autenticacion;
using NetCoreAngular.WebApi.GlobalErrorsHandling;

namespace NetCoreAngular.WebApi
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
            services.AddTransient<ISupplierLogic, SupplierLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ITokenLogic, TokenLogic>();

            services.AddSingleton<IUnitOfWork>(option => new NorthwindUnitOfWork(
                Configuration.GetConnectionString("Northwind")
                ));
            var tokenProvider = new JwtProvider("issuer", "audience", "northwind_2000");
            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });
            services.AddAuthorization(auth=>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();
            app.ConfigureExceptionsHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

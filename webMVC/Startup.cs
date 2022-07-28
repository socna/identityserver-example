using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using webMVC.Services;

namespace webMVC
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
            IdentityModelEventSource.ShowPII = true;
            services.AddControllersWithViews();

            services.AddAuthentication(options => {
                options.DefaultScheme= "cookie";
                options.DefaultChallengeScheme = "oidc";

            }).AddCookie("cookie")
            .AddOpenIdConnect("oidc", options => {
                options.Authority = Configuration["InteractiveServiceSettings:AuthorityUrl"];
                options.ClientId = Configuration["InteractiveServiceSettings:ClientId"];
                options.ClientSecret = Configuration["InteractiveServiceSettings:ClientSecret"];

                options.ResponseType = "code";
                options.UsePkce = true;
                options.ResponseMode = "query";

                options.CallbackPath = "/signin-oidc";

                options.Scope.Add(Configuration["InteractiveServiceSettings:Scopes:0"]);
                options.SaveTokens = true;
                options.RequireHttpsMetadata = false;
            });

            services.Configure<IdentityServerSettings>(Configuration.GetSection("IdentityServerSettings"));
            services.AddSingleton<ITokenService, TokenService>();
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
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.None });

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Contact}/{action=Index}/{id?}");
            });
        }
    }
}

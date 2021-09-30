using AccountManagement.Infrastructure.Configuration;
using BlogManagement.Infrastracture.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using UtilityFreamwork.Application;

namespace ServiceHost
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
         var connection = Configuration.GetConnectionString("Lampshade");

         services.AddHttpContextAccessor();

         ShopManagementConfigurator.Configure(services, connection);
         DiscountManagementConfigurator.Configure(services, connection);
         InventoryManagementConfigurator.Configure(services, connection);
         BlogManagementConfigurator.Configure(services, connection);
         AccountManagementConfigurator.Configure(services, connection);

         //Interal Services
         services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
         services.AddTransient<IFileUploader, FileUploader>();
         services.AddSingleton<IPasswordHasher, PasswordHasher>();
         services.AddTransient<IAuthHelper, AuthHelper>();
         services.AddRazorPages();

         //Coockies
         services.Configure<CookiePolicyOptions>(options =>
         {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.Lax;
         });

         services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
         .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
         {
            o.LoginPath = new PathString("/Account");
            o.LogoutPath = new PathString("/Account");
            o.AccessDeniedPath = new PathString("/AccessDenied");
         });
      }


      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
         else
         {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
         }
         app.UseAuthentication();
         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseCookiePolicy();
         app.UseRouting();
         app.UseAuthorization();
         app.UseEndpoints(endpoints =>
         {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
         });
      }
   }
}

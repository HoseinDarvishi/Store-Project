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
using System.Collections.Generic;
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

         //Coockies ==> Authentication
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
            o.AccessDeniedPath = new PathString("/NotFound");
         });

         //Authorize
         services.AddAuthorization(opt =>
         {
            opt.AddPolicy("AdminArea", user => user.RequireRole(new List<string> { AccountRoles.Manager, AccountRoles.ContentUploader,AccountRoles.Inventor }));
            opt.AddPolicy("Shop", user => user.RequireRole(new List<string> { AccountRoles.Manager }));
            opt.AddPolicy("Inventory", user => user.RequireRole(new List<string> { AccountRoles.Manager , AccountRoles.Inventor}));
            opt.AddPolicy("Discount", user => user.RequireRole(new List<string> { AccountRoles.Manager }));
            opt.AddPolicy("Users", user => user.RequireRole(new List<string> { AccountRoles.Manager }));
         });

         services.AddRazorPages().AddRazorPagesOptions(opt =>
         {
            opt.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
            opt.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
            opt.Conventions.AuthorizeAreaFolder("Administration", "/Inventory", "Inventory");
            opt.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
            opt.Conventions.AuthorizeAreaFolder("Administration", "/Account", "Users");
         });

         services.AddRazorPages();
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

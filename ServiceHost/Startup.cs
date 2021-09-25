using AccountManagement.Infrastructure.Configuration;
using BlogManagement.Infrastracture.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

         ShopManagementConfigurator.Configure(services, connection);
         DiscountManagementConfigurator.Configure(services, connection);
         InventoryManagementConfigurator.Configure(services, connection);
         BlogManagementConfigurator.Configure(services, connection);
         AccountManagementConfigurator.Configure(services, connection);

         services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
         services.AddTransient<IFileUploader, FileUploader>();
         services.AddSingleton<IPasswordHasher, PasswordHasher>();
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

         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseAuthorization();
         app.UseEndpoints(endpoints =>
         {
            endpoints.MapRazorPages();
            endpoints.MapDefaultControllerRoute();
         });
      }
   }
}

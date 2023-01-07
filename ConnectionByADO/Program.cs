/*
 *Before moving forward we would need to add a nugget package for Razor Pages compilation.
 * Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation -Version 5.0.6 ( Latest stable 6.0.12)
 *Now Create Controllers folder and Views Folder in Project
 * Add HomeController,cs in Controllers and Index.cshtml in View folder
 * Add Layout Page _Layout.cshtml Using add Razor Layout Options and add Bootstrap in this project in Views folder
 * Create wwwroot folder in project root
 * important thing is don't forger app.UseStaticFiles();
 */
using System;
using ConnectionByADO.Implementations;
using ConnectionByADO.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace ConnectionByADO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Add Services for MVC
            builder.Services.AddControllersWithViews();
            //Mke Sure While Add Custom service format should be maintained
            builder.Services.AddSingleton<IFetchServerInformation, GetServerInformation>();
            /*
             * After adding above MVC Controller services add the default router mapping
             */
            var app = builder.Build();
            //set up Enviroment Development
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.MapDefaultControllerRoute();
            //app.UseRouting();
            /*app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");*/
            //Close below line first
            /*app.MapGet("/", () => "Hello World!");*/

            app.Run();
        }
    }
}
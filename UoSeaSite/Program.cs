using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using UoSeaSite.Data;

namespace UoSeaSite
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddSingleton<WeatherForecastService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

            string physicalPath = (string)builder.Configuration.GetValue<string>("UOSeaServer:StasticFilePath");

            app.UseStaticFiles();
			app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(physicalPath),
                RequestPath = new PathString("/StaticFiles"),
                EnableDirectoryBrowsing = true
            });

            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(physicalPath),
            //    RequestPath = new PathString("/StaticFiles")
            //});

            app.UseStaticFiles();

			app.UseRouting();

			app.MapBlazorHub();
			app.MapFallbackToPage("/_Host");

			app.Run();
		}
	}
}
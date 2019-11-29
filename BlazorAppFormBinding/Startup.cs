using BlazorAppFormBinding.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorAppFormBinding
{
	public class Startup
	{
		#region Properties
		public IConfiguration Configuration { get; }
		#endregion

		#region Constructors
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}
		#endregion

		#region Publics
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddSingleton<WeatherForecastService>();

			SqlConnectionConfiguration sqlConnectionConfiguration = new SqlConnectionConfiguration(this.Configuration.GetConnectionString("SqlDbContext"));
			services.AddSingleton(sqlConnectionConfiguration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			                 {
				                 endpoints.MapBlazorHub();
				                 endpoints.MapFallbackToPage("/_Host");
			                 });
		}
		#endregion
	}
}
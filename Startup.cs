using wwrk.Domain.Entities;

namespace wwrk
{
	internal class StartUp
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
		}
		public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage(); // ƒл€ подробных вы€влени€ ошибок
			app.UseRouting();


            app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGIBack.Repositories;
using CGIBack.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CGIBack
{
	public class Startup
	{

		readonly string AllowSpecificOrigins = "_allowSpecificOrigins";
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options => {
				options.AddPolicy(name: AllowSpecificOrigins,
								  builder => {
									  builder.WithOrigins("http://localhost:4200");
								  });
			});
			services.AddTransient<IMovieRepository, MovieRepository>();
			services.AddTransient<IMovieService, MovieService>();
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(AllowSpecificOrigins);

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Movies}/{action=Index}/{id?}");
			});
		}
	}
}

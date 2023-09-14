using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
	public class Startup
	{
		private readonly IConfiguration _configuration;
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(_configuration.GetConnectionString("Default"));
			});

			services.AddIdentity<AppUser, IdentityRole>(identityOption =>
			{
				identityOption.Password.RequiredLength = 8;
				identityOption.Password.RequireNonAlphanumeric = false;
				identityOption.Lockout.MaxFailedAccessAttempts= 5;
				identityOption.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(1);
				identityOption.User.RequireUniqueEmail = true;	
				identityOption.Lockout.AllowedForNewUsers= true;
				

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
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
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();	
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}

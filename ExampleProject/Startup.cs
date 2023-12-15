using ExampleProject.Data;
using ExampleProject.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        { 
            services.AddControllersWithViews();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<StoreDbContext>();
            services.AddScoped<AccountRepository, AccountRepository>();
            services.AddScoped<PagesRepository,PagesRepository>();
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Integrated Security=True;Encrypt=False;Database=ExampleProject");
            });
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/SignIn";
            });

        }
        public void Configure(IApplicationBuilder app , IWebHostEnvironment env) 
        { 
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

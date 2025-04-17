using DataAsseccLayer.Concreat;
using DataAsseccLayer.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
StaartUp(builder.Services, builder.Configuration);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddHostedService<NewsSchedulerService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1600); // Время жизни сессии
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseStaticFiles();

//app.UseExceptionHandler("/ErrorPage/Page404/"); // Xatolar sahifasiga yo'naltirish

//app.UseStatusCodePagesWithRedirects("/ErrorPage/Page404/"); // Muayyan xato koddagi muharrirga yo'naltirish

app.UseHttpsRedirection();


app.UseRouting();


app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();

static void StaartUp(IServiceCollection services, ConfigurationManager manager)
{
    services.AddControllersWithViews();

        services.AddControllersWithViews();


	//services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

	services.AddAuthentication(

		CookieAuthenticationDefaults.AuthenticationScheme).
		AddCookie(options =>
		{
			options.LogoutPath = "/Login/Index";
		});


	services.AddHttpContextAccessor();
	services.AddMvc();
	services.AddControllersWithViews();
} 

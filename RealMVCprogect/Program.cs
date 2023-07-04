using DataAsseccLayer.Concreat;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
StaartUp(builder.Services, builder.Configuration);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
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

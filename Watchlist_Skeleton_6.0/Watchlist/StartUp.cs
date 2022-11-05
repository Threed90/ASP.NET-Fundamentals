using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Entities;
using Watchlist.Services;
using Watchlist.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("WatchlistContextConnection");
builder.Services.AddDbContext<WatchlistDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WatchlistDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/User/Login";
});

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

using Microsoft.EntityFrameworkCore;
using Mouse.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MouseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));
var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//launch settins.json ma hunxa yo
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You
    //
    //
    //
    // may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

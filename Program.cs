using amirProject.Data;
using amirProject.Repositery;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AnimalsContext>(options => options.UseSqlite("DataSource = MyDb.db"));
builder.Services.AddTransient<IAnimalServices, AnimalRepo>();
//builder.Services
var app = builder.Build();

app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


using Microsoft.EntityFrameworkCore;
using ThinhQuangAnh_241230659.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QlhangHoaContext>(options =>
options.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=QLHangHoa;Trusted_Connection=True;TrustServerCertificate=True;"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

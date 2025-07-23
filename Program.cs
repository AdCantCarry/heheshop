using heheshop.Models; // thêm dòng này
using heheshop.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HeheDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HeheDb")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Chỉ migrate, không gọi Seed lại
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<HeheDbContext>();
    context.Database.Migrate(); // sẽ tự gọi SeedData thông qua OnModelCreating
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseMiddleware<heheshop.Middleware.AuthMiddleware>();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

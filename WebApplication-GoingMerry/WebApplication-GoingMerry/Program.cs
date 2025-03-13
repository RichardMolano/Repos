using WebApplication_GoingMerry.DAL;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar el contexto en el contenedor de servicios (DI)
builder.Services.AddDbContext<TripContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TripContext")));



// 2. Agregar otros servicios
builder.Services.AddControllersWithViews();

// 3. Construir la aplicación
var app = builder.Build();

// 4. Configurar middlewares y pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TripContext>();
    TripInitializer.Seed(context);
}

// 5. Mapear rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
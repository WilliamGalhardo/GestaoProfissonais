using Microsoft.EntityFrameworkCore;
using GestaoProfissionais.Data; // Namespace onde o seu DbContext está
using GestaoProfissionais.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting; // Namespace onde seus modelos estão

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext para usar a string de conexão do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // Lendo a string de conexão do appsettings.json

// Adicionando os serviços necessários (MVC, Razor Pages, etc.)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração de middleware (como roteamento, etc.)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

var builder = WebApplication.CreateBuilder(args);

// Agregar servicio al contenedor
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar la canalización de solicitudes.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es de 30 días. Es posible que desee cambiarlo para escenarios de producción, consulte  https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
var supportedCultures = new[] { "es-SV", "es-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    // CAMBIO AQUÍ: Cambiamos Productos por Home e Index
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

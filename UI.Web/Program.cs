using Business.Middlewares;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// IOC sýnýfýndaki uzantýlarý kullanarak servisleri ekliyoruz.
builder.Services.AddDataConnections(builder.Configuration);
builder.Services.AddAccounts();
builder.Services.AddMallServices();

var app = builder.Build();

// IsDevelopment metodu, uygulamanýn geliþtirme ortamýnda mý çalýþtýðýný kontrol eder. Geliþtirme ortamýnda hata sayfalarý ve diðer geliþtirme araçlarý etkinleþtirilir.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Home/Error");
    // HSTS (HTTP Strict Transport Security) nedir?: Uygulamanýn sadece HTTPS üzerinden eriþilmesini zorunlu kýlarak güvenliði artýran bir web güvenlik politikasýdýr.
    app.UseHsts();
}

// HTTPS yönlendirmesi, tüm HTTP isteklerini otomatik olarak HTTPS'ye yönlendirir.
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("about", "about", new { controller = "Home", action = "About" });
app.MapControllerRoute("contact", "contact", new { controller = "Home", action = "Contact" });
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Business.Middlewares;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddLanguages();

builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

// IOC s�n�f�ndaki uzant�lar� kullanarak servisleri ekliyoruz.
builder.Services.AddDataConnections(builder.Configuration);
builder.Services.AddAccounts();
builder.Services.AddMallServices();



var app = builder.Build();
var supportedCultures = new[] { "en", "tr" };
app.UseRequestLocalization(new RequestLocalizationOptions().SetDefaultCulture("en")
                                                           .AddSupportedCultures(supportedCultures)
                                                           .AddSupportedUICultures(supportedCultures));

// IsDevelopment metodu, uygulaman�n geli�tirme ortam�nda m� �al��t���n� kontrol eder. Geli�tirme ortam�nda hata sayfalar� ve di�er geli�tirme ara�lar� etkinle�tirilir.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Home/Error");
    // HSTS (HTTP Strict Transport Security) nedir?: Uygulaman�n sadece HTTPS �zerinden eri�ilmesini zorunlu k�larak g�venli�i art�ran bir web g�venlik politikas�d�r.
    app.UseHsts();
}

// HTTPS y�nlendirmesi, t�m HTTP isteklerini otomatik olarak HTTPS'ye y�nlendirir.
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("about", "about", new { controller = "Home", action = "About" });
app.MapControllerRoute("contact", "contact", new { controller = "Home", action = "Contact" });
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();

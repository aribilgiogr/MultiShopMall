using Business.Middlewares;
using Core.Resources;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Utilities.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddLanguages();

builder.Services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(opt =>
                {
                    opt.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var localizer = factory.Create(typeof(SharedResource));
                        LocalizerHelper<SharedResource>.Init(factory);
                        return localizer;
                    };
                }
    );

// IOC sýnýfýndaki uzantýlarý kullanarak servisleri ekliyoruz.
builder.Services.AddDataConnections(builder.Configuration);
builder.Services.AddAccounts();
builder.Services.AddMallServices();


var app = builder.Build();
var supportedCultures = new[] { "en", "tr" };

var localizationOptions = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture("tr"),
    SupportedCultures = [.. supportedCultures.Select(c => new CultureInfo(c))],
    SupportedUICultures = [.. supportedCultures.Select(c => new CultureInfo(c))]
};

localizationOptions.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
localizationOptions.RequestCultureProviders.Insert(1, new CookieRequestCultureProvider());

app.UseRequestLocalization(localizationOptions);

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

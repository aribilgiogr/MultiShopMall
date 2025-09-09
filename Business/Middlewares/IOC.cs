using Business.Services;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.Entities.Accounts;
using Data;
using Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Middlewares
{
    // IOC (Inversion of Control) nedir?: IOC, nesne oluşturma ve bağımlılık yönetimini uygulama kodundan ayıran bir tasarım prensibidir (design principle). Bu, kodun daha esnek, test edilebilir ve sürdürülebilir olmasını sağlar. IOC, genellikle Dependency Injection (DI) ile birlikte kullanılır. Sıralı bir şekilde tanımlamalar yapılmalıdır. Önceki tanımlanan yapılar sonraki tanımlamalarda kullanılabilir.
    public static class IOC
    {
        public static IServiceCollection AddDataConnections(this IServiceCollection services, IConfiguration configuration)
        {
            // Veritabanı için sqlite kullanarak Context yapısını diğer hismetlerin kullanabilmesi için en üste ekleriyoruz. Ayrıca bu satır sayesinde projye sen bir veritabanı kullanıyorsun demiş oluyoruz.
            services.AddDbContext<MallContext>(options => options.UseSqlite(configuration.GetConnectionString("SqliteConnection"), b => b.MigrationsAssembly("UI.Web")));

            return services;
        }

        public static IServiceCollection AddAccounts(this IServiceCollection services)
        {
            // Sıradaki servisimiz Identity için gerekli satır.
            services.AddIdentity<Member, MemberRole>() // Identity sistemini Member ve MemberRole sınıfları ile yapılandırır. Bu, kullanıcı ve rol yönetimi için gerekli olan temel işlevselliği sağlar.
                    .AddEntityFrameworkStores<MallContext>() // Identity'nin kullanıcı ve rol bilgilerini saklamak için Entity Framework Core'u kullanmasını sağlar. Bu, kullanıcı ve rol verilerinin veritabanında depolanmasını sağlar.
                    .AddDefaultTokenProviders(); // Parola sıfırlama, e-posta doğrulama gibi işlemler için gerekli olan token sağlayıcılarını ekler.
            return services;
        }

        public static IServiceCollection AddMallServices(this IServiceCollection services)
        {
            // Unit of Work Pattern için gerekli satır.
            // Scoped: Bir istek (request) süresince aynı nesne örneğini (instance) kullanır. Web uygulamalarında genellikle her HTTP isteği için bir örnek oluşturulur.
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Geçiş servisleri için gerekli tanımlamalar.
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IShowroomService, ShowroomService>();
            services.AddScoped<ISalesService, SalesService>();

            return services;
        }
    }
}

using DataAccess.Contexts;
using DataAccess.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service.Extensions;
using WebAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısını ekle
builder.Services.AddDbContext<WebSiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"))
);

// AddExtensions metodunu çağırarak tüm servisleri ekleyelim (kimlik doğrulama, JWT, Identity vb.)
builder.Services.AddExtensions(builder.Configuration);

// CORS Politikası (Vue.js için izin verildi)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
});

// Swagger/OpenAPI yapılandırması
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Token kullanımı: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

// MVC Controller desteği
builder.Services.AddControllers();

var app = builder.Build();

// Hata yakalama middleware'ini ekleyin
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePages();
}

// Geliştirme ortamında Swagger UI aktif et
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
        c.RoutePrefix = string.Empty;
    });
}

// HTTPS yönlendirmesi
app.UseHttpsRedirection();

// CORS Kullanımı
app.UseCors("AllowFrontend");

// Kimlik doğrulama ve yetkilendirme sırası önemli!
app.UseAuthentication();
app.UseAuthorization();

// API Controller'ları eşle
app.MapControllers();

// Uygulama başlatıldıktan sonra log kaydı olmadan konsola çıktı
Console.WriteLine("Uygulama başlatıldı!");

app.Run();

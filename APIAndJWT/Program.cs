using APIAndJWT.Domain.Entities;
using APIAndJWT.Domain.Repositories;
using APIAndJWT.Domain.Services;
using APIAndJWT.Domain.UnitOfWork;
using APIAndJWT.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IProductService, ProductService>(); //her karþýlaþtýðýnda nesne oluþturur.
builder.Services.AddScoped<IProductService, ProductService>(); //bir kere nesne oluþtutur bir request boyunca her karþýlaþtýðýnda onu kullanýr.
//builder.Services.AddSingleton<IProductService, ProductService>(); //bir kere nesne oluþtutur bir request boyunca ve uygulamanýn yaþam döngüsü býyunca her karþýlaþtýðýnda onu kullanýr.

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); //izinler veriliyor.
    });

    ////Sadece bu siteden gelen isteklere cevap verilmesi
    //opts.AddPolicy("abcPolicy", builder =>
    //{
    //    builder.WithOrigins("https://www.abc.com").AllowAnyHeader().AllowAnyMethod();
    //});
});

builder.Services.AddDbContext<UdemyAPIContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnectionString"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseCors("abcPolicy"); //sadece istediðimiz bir siteye izin verirsek middleware bu þekilde ekliyoruz.


app.UseCors();

app.Run();

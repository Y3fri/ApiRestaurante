using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using Restaurant.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string MiCors = "MiCors";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors,
        builder =>
        {
            builder.WithHeaders("*");
            builder.WithOrigins("*");
            builder.WithMethods("*");
        });
});


builder.Services.AddDbContext<RestauranteBDContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Yefer"));
});

builder.Services.AddScoped<IDepartamentoService,DepartamentoService>();
builder.Services.AddScoped<IMunicipioService, MunicipioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMProductoService, MProductoService>();
builder.Services.AddScoped<IDescuentoService, DescuentoService>();
builder.Services.AddScoped<IPInfService, PInfService>();
builder.Services.AddScoped<IPProductoService, PProductoService>();
builder.Services.AddScoped<IRInfService, RInfService>();
builder.Services.AddScoped<IRSedeService, RSedeService>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MiCors);
app.UseAuthorization();

app.MapControllers();

app.Run();

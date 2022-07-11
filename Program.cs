

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Models;
using Restaurant.Models.Common;
using Restaurant.Models.Services;
using Restaurant.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string MiCors = "MiCors";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<RestauranteBDContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Yefer"));
});

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



builder.Services.AddScoped<IDepartamentoService,DepartamentoService>();
builder.Services.AddScoped<IMunicipioService, MunicipioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMProductoService, MProductoService>();
builder.Services.AddScoped<IDescuentoService, DescuentoService>();
builder.Services.AddScoped<IPInfService, PInfService>();
builder.Services.AddScoped<IPProductoService, PProductoService>();
builder.Services.AddScoped<IRInfService, RInfService>();
builder.Services.AddScoped<IRSedeService, RSedeService>();
builder.Services.AddScoped<ISsoUsuarioService, SsoUsuarioService>();
builder.Services.AddScoped<ISsoUsuarioAgregarService, SsoUsuarioAgregarService>();


builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);


//JWT
var appSettings = appSettingsSection.Get<AppSettings>();
var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);
builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(d =>
    {
        d.RequireHttpsMetadata = false;
        d.SaveToken = true;
        d.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(llave),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MiCors);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

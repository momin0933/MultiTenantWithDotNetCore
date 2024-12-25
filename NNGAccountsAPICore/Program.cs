using Microsoft.EntityFrameworkCore;
using NNGAccountsAPICore.Service.Models;
using NNGAccountsAPICore.Service.DataLayer.Interface;
using NNGAccountsAPICore.Service.DataLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NNGAccountsCS;
using NNGAccountsAPICore.Service.DataLayer.Service;

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors();
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//         builder =>
//         {
//             builder.WithOrigins("http://localhost:4200/")
//                                 .AllowAnyHeader()
//                                 .AllowAnyMethod();
//         });
//});
//builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
//{
//    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
//}));
// Add services to the container.
//Donot forgot to add ConnectionStrings as "dbConnection" to the appsetting.json file
SQLConnectionString connectionService = new SQLConnectionString();
//string CS = connectionService.GetConnectionString();
string CS = "Data Source=172.20.3.152\\MSSQL2017;Initial Catalog=NNGAccounts;Uid = sa; Password = aA@01737918236;";
builder.Services.AddDbContext<AccountsDbContext>
    (options => options.UseSqlServer(CS));
string CS1 = "Data Source=172.20.3.152\\MSSQL2017;Initial Catalog=NMLProperty2122;Uid = sa; Password = aA@01737918236;";
builder.Services.AddDbContext<NmlDbContext>
    (options => options.UseSqlServer(CS1));

//builder.Configuration.GetConnectionString("AccountsCS");
builder.Services.AddTransient<IUsers, UserRepository>();
builder.Services.AddTransient<IMenuMaster, MenuMasterRepository>();
builder.Services.AddTransient<IGLMst, GLMstRepository>();
builder.Services.AddTransient<ILGMst, LGMstRepository>();
builder.Services.AddTransient<ICategory, CategoryRepository>();
builder.Services.AddTransient<IReference, ReferenceRepository>();


builder.Services.AddTransient<DapperService>();
builder.Services.AddTransient<ITenantService, TenantRepository>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

SQLConnectionString _connection = new SQLConnectionString();
//builder.Services.Configure<TenantSettings>(_connection.GetConnectionStringList().ToList());
//builder.Services.Configure<TenantSettings>(builder.Configuration.GetSection(nameof(Tenants)));
//services.Configure<TenantSettings>(config.GetSection(nameof(TenantSettings)));
//ConnectionStringService otherscs = new ConnectionStringService();
builder.Services.AddTransient<ConnectionStringService>();
builder.Services.AddTransient<SQLConnectionString>();
builder.Services.AddScoped<SQLConnectionString>();


builder.Services.AddControllers();
builder.Services.AddControllers()
           .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credenti

//app.UseRouting();  // first
// Use the CORS policy

//app.UseCors(MyAllowSpecificOrigins); // second
app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
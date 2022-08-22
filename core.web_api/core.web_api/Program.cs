using core.web_api.Filteri;
using database.trading;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using servisi.trading;
using servisi.trading.Configuration;
using servisi.trading.EmailConfiguration;
using System.Net;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
    logging.AddDebug();
    logging.AddConsole();
});

//cors

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                          builder.AllowAnyMethod();
                          builder.AllowAnyHeader();
                      });
});
//dependency injection for IConfiguring

////OAuth services setup
var key = builder.Configuration.GetValue<string>("Token"); //getting toke from app configuration

var token = Encoding.ASCII.GetBytes(key); //encoding the key with ASCII

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt => {
    jwt.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(token), //using simple symetric key for signing
        ValidateIssuerSigningKey = true, //requesting validation of the issuer key
        ValidateIssuer = true, //requesting issuer validation
        ValidateAudience = true, //requesting audience validation
        ValidIssuer = Constants.issuer,
        ValidAudiences = new List<string> { Constants.issuer, Constants.mobile_audience }//swagger and angular localhost addresses 
    };
});

var emailConfig = builder.Configuration
.GetSection("EmailConfiguration")
.Get<EmailConfig>();

builder.Services.AddSingleton(emailConfig);

// Add services to the container.


builder.Services.AddControllers(x => {
    x.Filters.Add<AuthorizationFilter>();
    x.Filters.Add<ErrorHandelingFilter>();
    x.Filters.Add<BaseResourcesFilter>();
    x.Filters.Add<BaseActionFilter>();
}); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "trading.rs2", Version = "v1" });
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "bearerAuth"
                                }
                            },
                            new string[] {}
                    }
                });
});

builder.Services.ProvideServices();

builder.Services.AddAutoMapper(typeof(MappingProfili));

//dependency injection for IConfiguring

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

using GoldenAirport.Application.Auth.Services;
using GoldenAirport.Application.Helpers;
using GoldenAirport.Application.Infrastructure;
using GoldenAirport.Application.Interfaces;
using GoldenAirport.Application.Users.Queries.Login;
using GoldenAirport.Domain.Entities.Auth;
using GoldenAirport.Infrastructure.Presistence;
using GoldenAirport.WebAPI.Middlewares;
using GoldenAirport.WebAPI.Models;
using Hedaya.Application.Auth.Abstractions;
using Hedaya.Application.Auth.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}
).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],
    ValidAudience = builder.Configuration["JWT:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
});

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.ConfigureApplicationCookie(o =>
{
    o.ExpireTimeSpan = TimeSpan.FromDays(5);
    o.SlidingExpiration = true;
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromHours(3));

//Add Send Grid Service For Sending Emails
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);


//Add Localization
builder.Services.AddLocalization();
builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
builder.Services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        factory.Create(typeof(JsonStringLocalizerFactory));
    });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG"),
    };

    options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[1], uiCulture: supportedCultures[1]);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});


//Add Mediator Services
builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(typeof(ApplicationDbContext).Assembly);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});



// Add ApiExplorer to discover versions
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v4", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
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
            new string[] { }
        }
    });
});


// Serilog Config
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

//var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();


var app = builder.Build();




app.UseMiddleware<ExceptionHandlerMiddleware>();

//Keep Tokins
app.UseSwaggerUI(c =>
{
    c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
});


var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            description.GroupName.ToUpperInvariant());
    }
});



app.UseCors("AllowAll");

app.UseSerilogRequestLogging();


app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseAuthentication();

var supportedCultures = new[] { "en-US", "ar-EG" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[1]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);


app.UseAuthorization();

app.MapControllers();


try
{
    Log.Information("Application Starting");
    app.Run();
}
catch (Exception ex)
{

    Log.Fatal(ex, "The Application Failed To Start");
}
finally
{
    Log.CloseAndFlush();
}




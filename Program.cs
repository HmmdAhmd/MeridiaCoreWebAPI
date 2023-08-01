using MeridiaCoreWebAPI.Authorization;
using MeridiaCoreWebAPI.Constants;
using MeridiaCoreWebAPI.Constants.Messages;
using MeridiaCoreWebAPI.Core;
using MeridiaCoreWebAPI.Data;
using MeridiaCoreWebAPI.Models;
using MeridiaCoreWebAPI.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;
using OpenIddict.Validation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration[ConfigurationConstants.CONNECTION_STRING]
    ?? throw new InvalidOperationException(ErrorMessages.CONNECTION_STRING_NOT_FOUND);

builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString, builder => builder
    .CommandTimeout(900)
    .EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), new List<int>() { 3, 4, 5, 6, 7, 8, 9, 11, 16, 17, 40197 }));
    options.UseOpenIddict();
});

builder.Services.AddTransient<UtilityFunctions>();
builder.Services.AddScoped<TemplateCore>();
builder.Services.AddScoped<SubscriptionCore>();
builder.Services.AddScoped<ParticipantManagementCore>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.UserNameClaimType = OpenIddictConstants.Claims.Name;
    options.ClaimsIdentity.UserIdClaimType = OpenIddictConstants.Claims.Subject;
    options.ClaimsIdentity.RoleClaimType = OpenIddictConstants.Claims.Role;
    options.ClaimsIdentity.EmailClaimType = OpenIddictConstants.Claims.Email;
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddOpenIddict()
   .AddCore(options =>
   {
       options.UseEntityFrameworkCore()
              .UseDbContext<ApplicationDbContext>();
   })

   .AddServer(options =>
   {
       options.SetTokenEndpointUris(AuthEndpoints.EXCHANGE_TOKEN);

       options.AllowPasswordFlow();

       options.AllowRefreshTokenFlow();

       options.AcceptAnonymousClients();

       options.RegisterScopes(OpenIddictConstants.Scopes.Email, OpenIddictConstants.Scopes.Profile, OpenIddictConstants.Scopes.OpenId,
           OpenIddictConstants.Scopes.Roles, OpenIddictConstants.Scopes.OfflineAccess);

       options.AddDevelopmentEncryptionCertificate()
              .AddDevelopmentSigningCertificate();

       options.UseAspNetCore()
              .EnableTokenEndpointPassthrough();
   })

   .AddValidation(options =>
   {
       options.UseLocalServer();

       options.UseAspNetCore();
   });

builder.Services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.AdministratorRolePolicy, policy => policy.RequireRole(Roles.Administrator));
    options.AddPolicy(Policies.OperatorRolePolicy, policy => policy.RequireRole(Roles.Operator, Roles.Administrator));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

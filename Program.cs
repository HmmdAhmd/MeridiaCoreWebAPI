using MeridiaCoreWebAPI.Authorization;
using MeridiaCoreWebAPI.Constants;
using MeridiaCoreWebAPI.Constants.Messages;
using MeridiaCoreWebAPI.Data;
using MeridiaCoreWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;
using OpenIddict.Validation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration[ConfigurationConstants.CONNECTION_STRING]
    ?? throw new InvalidOperationException(ErrorMessages.CONNECTION_STRING_NOT_FOUND);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    // Register the entity sets needed by OpenIddict.
    options.UseOpenIddict();
});

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
       options.SetTokenEndpointUris("connect/token");

       options.AllowPasswordFlow();

       options.AllowRefreshTokenFlow();

       options.AcceptAnonymousClients();

       options.DisableAccessTokenEncryption();

       options.RegisterScopes(OpenIddictConstants.Scopes.Email, OpenIddictConstants.Scopes.Profile, OpenIddictConstants.Scopes.OpenId, OpenIddictConstants.Scopes.Roles, OpenIddictConstants.Scopes.OfflineAccess);

       // Register the signing and encryption credentials.
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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

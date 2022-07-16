using EXShop.RazorPage.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Account", builder =>
    {
        builder.RequireAuthenticatedUser();
    });
    option.AddPolicy("SellerPanel", builder =>
    {
        builder.RequireAuthenticatedUser();
        builder.RequireAssertion(a => a.User.Claims.Any(b => b.Type == ClaimTypes.Role && b.Value == "5"));
    });
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation().AddRazorPagesOptions(options =>
{
    options.Conventions.AuthorizeFolder("/Profile", "Account");
    options.Conventions.AuthorizeFolder("/SellerPanel", "SellerPanel");
});

builder.Services.RegisterApiServices();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SignInKey"])),
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true
    };
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["token"]?.ToString();
    if (string.IsNullOrWhiteSpace(token) == false)
    {
        context.Request.Headers.Append("Authorization", $"Bearer {token}");
    }
    await next();
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.Use(async (context, next) =>
{
    await next();
    var status = context.Response.StatusCode;
    if (status == 401)
    {
        var path = context.Request.Path;
        context.Response.Redirect($"/auth/login?redirectTo={path}");
    }
});

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();

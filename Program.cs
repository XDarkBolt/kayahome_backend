using FluentValidation.AspNetCore;
using kayahome_backend.Hubs;
using kayahome_backend.Models.Filters;
using Microsoft.OpenApi.Models;

var MyAllowSpecificOrigins = "specOrigin";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(options => options.Filters.Add(typeof(ExceptionFilter)))
    .AddFluentValidation();

builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "KAYA HOME API Document",
        Description = "KAYA HOME Automation applications",
        TermsOfService = new Uri("https://kayahuseyin.com.tr"),
        Contact = new OpenApiContact
        {
            Name = "Huseyin Kaya",
            Url = new Uri("https://kayahuseyin.com.tr")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://kayahuseyin.com.tr")
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapHub<NotificationHub>("/NotificationHub");

//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

using Microsoft.AspNetCore.ResponseCompression;
using MediaLibrary.Server.Data;
using Microsoft.EntityFrameworkCore;
using MediaLibrary.Server;
using MediaLibrary.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MediaLibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediaLibraryDT")); // Use MediaLibraryDT when working on the Desktop;
    //options.UseSqlServer(builder.Configuration.GetConnectionString("MediaLibrary")); // Use MediaLibrary when working on the laptop; 
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddTransient<MovieService>();
builder.Services.AddTransient<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();


app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

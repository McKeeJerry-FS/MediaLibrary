using MediaLibrary.Server;
using MediaLibrary.Server.Data;
using MediaLibrary.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MediaLibraryDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("MediaLibraryDT")); // Use MediaLibraryDT when working on the Desktop;
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediaLibrary")); // Use MediaLibrary when working on the laptop; 
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(MapperProfile), typeof(MediaLibrary.Shared.SharedMapperProfile));
builder.Services.AddTransient<MovieService>();
builder.Services.AddTransient<PersonService>();
builder.Services.AddGrpc();

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
app.UseGrpcWeb();


app.MapRazorPages();
app.MapControllers();
app.MapGrpcService<MediaLibrary.Server.Contracts.PersonContractService>()
    .EnableGrpcWeb();
app.MapGrpcService<MediaLibrary.Server.Contracts.MovieContractService>()
    .EnableGrpcWeb();
app.MapFallbackToFile("index.html");

app.Run();

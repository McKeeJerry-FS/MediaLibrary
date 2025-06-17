using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using MediaLibrary.Server.Data;
using MediaLibrary.Server;
using MediaLibrary.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MediaLibraryDbContext>(options =>
{
    // If working on this at home, use MediaLibraryDesktop for database access, other wise use MediaLibrary
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediaLibraryDesktop"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("MediaLibrary"));
#if DEBUG
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
#endif
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddTransient<MovieService>();
builder.Services.AddTransient<PersonService>();
builder.Services.AddAutoMapper(typeof(MapperProfile), typeof(MediaLibrary.Shared.SharedMapperProfile));

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
app.MapGrpcService<MediaLibrary.Server.Contracts
   .PersonContractService>()
   .EnableGrpcWeb();
app.MapFallbackToFile("index.html");

app.Run();

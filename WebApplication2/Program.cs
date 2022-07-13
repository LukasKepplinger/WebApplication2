using Microsoft.EntityFrameworkCore;
using WebApplication2;
using WebApplication2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// The service has to ba a singleton! 
// If u use AddTransient instead the cunstructor in the page will get a new Object of FakePersonDb
// This also means that this object has its own list which will be empty again
builder.Services.AddSingleton<FakePersonsDb>();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;MultipleActiveResultSets=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

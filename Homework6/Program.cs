using Homework6.Services;
using Homework6.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Puppies.Dal.RepoInterface;
using Puppies.Dal.Repos.DapperRepo;
using Puppies.Dal.Repos.EFRepo;
using Puppies.Dal.Repos.EFRepo.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DockerConnectionString");

InitializeORM();

builder.Services.AddScoped<IPuppyService, PuppyService>();
builder.Services.AddScoped<IBreedService, BreedService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void InitializeORM()
{
    var ormsJson = builder.Configuration.GetSection("ORM").GetChildren();

    string provider = string.Empty;

    foreach(var item in ormsJson)
    {
        if (item.Get<bool>()) provider = item.Key;
    }

    switch (provider)
    {
        case "Dapper":
            builder.Services.AddScoped<IPuppyRepo, PuppyDapperRepo>(x => new PuppyDapperRepo(connectionString));
            builder.Services.AddScoped<IBreedRepo, BreedDapperRepo>(x => new BreedDapperRepo(connectionString));
            break;
        case "EFCore":
            builder.Services.AddDbContext<PuppyContext>(options =>
                options.UseSqlServer(builder.Configuration
                .GetConnectionString("DockerConnectionString")));

            builder.Services.AddScoped<IPuppyRepo, PuppyEFRepo>();
            builder.Services.AddScoped<IBreedRepo, BreedEFRepo>();
            break;
    }
}
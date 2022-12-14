using DataAccess.Data;
using MarinFinancialSample.Data;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryDbContext>();
builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddTransient<IBookInstanceRepo, BookInstanceRepo>();
builder.Services.AddTransient<IAuthorRepo, AuthorRepo>();
builder.Services.AddTransient<IGenreRepo, GenreRepo>();

var allOrigins = "AllOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(allOrigins,
        policy =>
        {
            policy.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<LibraryDbContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseCors(allOrigins);
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using TrelloBack.Models;
using TrelloBack.Models.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProjetDAO, ProjetDAO>();
builder.Services.AddScoped<IListeDAO, ListeDAO>();
builder.Services.AddScoped<ITacheDAO, TacheDAO>();
builder.Services.AddScoped<ICommentaireDAO, CommentaireDAO>();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200", "https://projetfilerouge.azurewebsites.net")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projets}/{action=GetProjets}");

app.Run();

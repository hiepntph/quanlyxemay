var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession(c =>
    {
        c.IOTimeout = TimeSpan.FromDays(1);
    }
);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(c =>
{
    c.IOTimeout = TimeSpan.FromSeconds(20);
    c.Cookie.HttpOnly = true;
    c.Cookie.IsEssential = true;
}
            );
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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

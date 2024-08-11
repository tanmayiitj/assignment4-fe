var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "GetEmployeeData",
        pattern: "Home/GetEmployeeData/{id?}",
        defaults: new { controller = "Home", action = "GetEmployeeData" });

    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    _ = endpoints.MapControllerRoute(
        name: "AddEmployee",
        pattern: "Home/AddEmployee/",
        defaults: new { controller = "Home", action = "AddEmployee" });
    _ = endpoints.MapControllerRoute(
        name: "UpdateEmployee",
        pattern: "Home/UpdateEmployee/",
        defaults: new { controller = "Home", action = "UpdateEmployee" });
    _ = endpoints.MapControllerRoute(
        name: "DeleteEmployee",
        pattern: "Home/DeleteEmployee/{id?}",
        defaults: new { controller = "Home", action = "DeleteEmployee" });
});

app.Run();


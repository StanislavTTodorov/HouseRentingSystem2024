

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);



builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentiry(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServises();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();

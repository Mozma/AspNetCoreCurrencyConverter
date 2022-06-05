using CurrencyConverterCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<IExchangeRateService, ExchangeRateService>(c =>
{
    c.BaseAddress = new Uri("https://api.exchangerate.host/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.MapControllerRoute(
    name: null,
    pattern: "{controller}/{action}",
    defaults: new { Controller = "Home" }
    );

app.MapControllerRoute(
    name: null,
    pattern: "{controller}/{action}/{id?}",
    defaults: new { Controller = "Home", action = "Index" }
    );

app.Run();

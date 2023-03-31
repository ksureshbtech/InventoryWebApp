var builder = WebApplication.CreateBuilder(args);

string inventoryUrl = builder.Configuration.GetValue<string>("InventoryServiceUrl");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient("CarClient", c =>
{
    c.DefaultRequestHeaders.Add("Accept", "application/json");
    c.BaseAddress = new Uri(inventoryUrl);
});

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

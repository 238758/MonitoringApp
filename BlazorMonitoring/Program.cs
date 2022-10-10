using BlazorMonitoring.Data;
using FM4017Library.DataServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Using httpclient factory to register a dataservice requesting an interface
// Making the service available for dependency injection (DI), giving loose coupling to the concrete implementation
builder.Services.AddHttpClient<ID4DataService, GraphQLD4DataService>
            (dimensionFourDataService =>
            {
                dimensionFourDataService.BaseAddress = new Uri(builder.Configuration["DimensionFour:ApiUrl"]);
                dimensionFourDataService.DefaultRequestHeaders.Add(builder.Configuration["DimensionFour:Header1Name"], builder.Configuration["DimensionFour:Header1Value"]);
                dimensionFourDataService.DefaultRequestHeaders.Add(builder.Configuration["DimensionFour:Header2Name"], builder.Configuration["DimensionFour:Header2Value"]);
            });

// Service to get Data, shared by all pages/ components
builder.Services.AddScoped<DataAccess>();


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

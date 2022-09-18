using FM4017Library.DataServices;
using FM4017Library.DataServices.SpaceX;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



//SpaceX (just for test)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["spacex_api_base_url"]) });
builder.Services.AddHttpClient<ISpaceXDataService, GraphQLSpaceXDataService>
    (spds => spds.BaseAddress = new Uri(builder.Configuration["spacex_api_base_url"]));

builder.Services.AddHttpClient<ID4DataService, GraphQLD4DataService>
            (spds => spds.BaseAddress = new Uri(builder.Configuration["DimensionFour:ApiUrl"]));

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

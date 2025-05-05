using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeatherApp1;
using WeatherApp1.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient with CORS handling
builder.Services.AddScoped(sp => 
{
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://api.weatherapi.com/v1/")
    };
    
    // Add headers that might help with API requests
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    
    return httpClient;
});

// Register the WeatherStateService for state management
builder.Services.AddScoped<WeatherStateService>();

await builder.Build().RunAsync();

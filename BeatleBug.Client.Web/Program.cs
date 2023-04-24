using BeatleBug.Client.Web;
using BeatleBug.Client.Web.Services.Contracts;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7143/api/") });
builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddScoped<IBugService, BugService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();

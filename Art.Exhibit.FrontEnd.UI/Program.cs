using Art.Exhibit.FrontEnd.Application;
using Art.Exhibit.FrontEnd.Infrastructure;
using Art.Exhibit.FrontEnd.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

await builder.Build().RunAsync();
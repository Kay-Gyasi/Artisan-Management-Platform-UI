using AMP.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RegisterDefaults();

try
{
    await builder.Build().RunAsync();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

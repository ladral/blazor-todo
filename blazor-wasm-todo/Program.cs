using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using blazor_wasm_todo.Data;
using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace blazor_wasm_todo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            
            // Add Fluxor
            builder.Services.AddFluxor(config =>
            {
                config
                    .ScanAssemblies(typeof(Program).Assembly)
                    .UseReduxDevTools();
            });
            
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<ITodoService, TodoServiceLocalStore>();
            
            await builder.Build().RunAsync();
        }
    }
}
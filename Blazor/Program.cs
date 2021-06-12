using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddMsalAuthentication<RemoteAuthenticationState, CustomUserAccount>(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
            })
            .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount, CustomAccountFactory>();

            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("Editor", policy => policy.RequireClaim("groups", "ab508bb5-ce57-4648-901b-3b3945c5aa1c"));
                options.AddPolicy("Administrator", policy => policy.RequireClaim("groups", "b508bb5-ce57-4648-901b-3b3945c5aa1c"));
            });

            await builder.Build().RunAsync();
        }
    }
}

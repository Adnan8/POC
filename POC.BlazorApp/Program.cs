using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using POC.BlazorApp.GraphQLServices;
using POC.BlazorApp;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register a default HttpClient for general use
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register a named HttpClient specifically for your GraphQL API
builder.Services.AddHttpClient("POCApi", client =>
    client.BaseAddress = new Uri("https://localhost:7186/graphql")); // Make sure the URL is correct

// Register the GraphQLHttpClient using the named HttpClient
builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(
    new GraphQLHttpClientOptions
    {
        EndPoint = new Uri("https://localhost:7186/graphql"), // This should match the client above
    },
    new NewtonsoftJsonSerializer(),
    s.GetRequiredService<IHttpClientFactory>().CreateClient("POCApi")
));

// Register Syncfusion Blazor
builder.Services.AddSyncfusionBlazor();

// Register your custom services
builder.Services.AddScoped<GraphQLService>(); // Assuming this service uses IGraphQLClient

await builder.Build().RunAsync();

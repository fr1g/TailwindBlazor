using TailwindBlazorApp.Components;
using TailwindBlazor;

var builder = WebApplication.CreateBuilder(args);

builder.UseTailwind();

//#if (UseServer && UseWebAssembly)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
//#elseif (UseServer)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//#elseif (UseWebAssembly)
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
//#else
builder.Services.AddRazorComponents();
//#endif

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
//#if (UseServer && UseWebAssembly)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();
//#elseif (UseServer)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
//#elseif (UseWebAssembly)
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode();
//#else
app.MapRazorComponents<App>();
//#endif

app.Run();

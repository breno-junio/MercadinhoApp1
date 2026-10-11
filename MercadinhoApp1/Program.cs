using MercadinhoApp1.Components;
using MercadinhoApp1.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// CORREÇÃO: Adiciona os serviços corretos para Blazor no .NET 8+
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Registra o serviço do Mercadinho como Singleton para manter os dados em memória
builder.Services.AddSingleton<MercadinhoService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var mercadinhoService = scope.ServiceProvider.GetRequiredService<MercadinhoService>();

    // Aguarda a inicialização dos dados de teste de forma assíncrona e segura
    await mercadinhoService.InicializarDadosAsync();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// CORREÇÃO: O token Antiforgery é obrigatório para formulários no Blazor do .NET 8+
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();



app.Run();

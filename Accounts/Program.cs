using Accounts.Components;
using Accounts.Data;
using Accounts.Data.Interfaces;
using Accounts.Data.UnitOfWork;
using Accounts.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AccountingDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
builder.Services.AddScoped(typeof(AccountServices));
builder.Services.AddScoped(typeof(AccountTypeServicse));
builder.Services.AddScoped(typeof(CostCenterServices));
builder.Services.AddScoped(typeof(MakeJournalServices));
builder.Services.AddScoped(typeof(SeedData));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
await SeedDatabase();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

async Task SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<SeedData>();
        await dbInitializer._intz();
    }
}
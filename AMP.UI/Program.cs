using Serilog;

var builder = WebApplication.CreateBuilder(args);
WebApplication app;
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Configuration.AddUserSecrets<Program>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(opts =>
    {
        opts.DetailedErrors = builder.Environment.IsDevelopment();
    });
builder.Services.AddServices(builder.Configuration);

try
{
    logger.Information("Amp UI starting up...");
    builder.Host.UseSerilog(logger);
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(logger);

    app = builder.Build();
    logger.Information("Amp UI started!");
}
catch (Exception)
{
    logger.Fatal("Startup failed!");
    throw;
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

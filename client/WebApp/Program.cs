using NToastNotify;
using WebApp.ServiceInterfaces;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mvcBuilder = builder.Services.AddRazorPages();

//#if DEBULG
//    mvcBuilder.AddRazorRuntimeCompilation();
//#endif

builder.Services.AddRazorPages ().AddNToastNotifyToastr ( new ToastrOptions () {
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight
} );

builder.Services.AddHttpClient ("WebApiClient", ( HttpClient) => {
    HttpClient.BaseAddress = new Uri ( builder.Configuration["ApiBaseUrl"]! );
} );

builder.Services.AddScoped<IHttpClientService, HttpClientService> ();
builder.Services.AddScoped<IDataService, DataService> ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//Use NToastNotify
app.UseNToastNotify ();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

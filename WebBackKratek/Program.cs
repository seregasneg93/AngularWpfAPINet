using KratekData.Data.ConnectDB;
using KratekServices.HubConfig;
using Microsoft.AspNet.SignalR;
using Microsoft.EntityFrameworkCore;
using WebBackKratek.HubConfig;

var builder = WebApplication.CreateBuilder(args);


//private Thread _th = new Thread(_teleofisServer.);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHostedService<TeleofisServer>();

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KratekAPIConnection"),b=>b.MigrationsAssembly("WebBackKratek")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  // MyHub.Current = app.ApplicationServices.GetService<IHubContext<NotificationFromServerHub>>();
//}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

//app.UseRouting();
app.MapControllers();
app.MapHub<ChatHub>("/toastr");

//TeleofisServer _teleofisServer = new();

app.Run();

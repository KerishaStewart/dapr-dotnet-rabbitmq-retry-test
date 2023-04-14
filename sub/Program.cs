var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddDapr();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appPort = int.Parse(builder.Configuration.GetValue<string>("AppPort"));
Console.WriteLine(appPort);
builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(appPort));

var app = builder.Build();
app.UseCloudEvents();

app.MapSubscribeHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
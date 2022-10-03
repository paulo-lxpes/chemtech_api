using CHEMTECH_API.ENDPOINTS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.MapCIDADEEndpoint();
app.MapCLIENTEEndpoint();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("corsapp");
app.UseHttpsRedirection();

app.Run();
using TaskListApi.Data.MongoDBSettings;
using TaskListApi.Interface.ITaskRepository;
using TaskListApi.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<ITaskRepository, TaskRepository>();

builder.WebHost.UseKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(Configuration.ApplicationPort);
});

var app = builder.Build();

// Configurar o middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Swagger na raiz
});

app.UseAuthorization();

app.MapControllers();

app.Run();

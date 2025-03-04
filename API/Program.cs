using API.Service;

var builder = WebApplication.CreateBuilder(args);

// Registrar MongoDBService como un servicio singleton
builder.Services.AddSingleton<MongoDBService>();

// Añadir los servicios necesarios para controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configurar el middleware para usar los controllers
app.MapControllers();

// Iniciar la aplicación
app.Run();

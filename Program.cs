var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHelloWorldService,HelloWorldService>();
builder.Services.AddScoped<ITareasServices,TareasServices>();
builder.Services.AddScoped<ICategoriaServices,CategoriaServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseWelcomePage();

app.UseAuthorization();


//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
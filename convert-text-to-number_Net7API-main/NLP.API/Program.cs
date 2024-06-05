using NLP.API.Services.Abstracts;
using NLP.API.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITextConversionService, TextConversionService>(); // S�n�f�m�z�, interface'in bir servisi olarak kaydettik.
                                                                             // Instance'� olu�tururken AddScoped'i tercih ettik. AddScoped her HTTP iste�inde yeni bir instance olu�turur.
builder.Services.AddScoped<IRegexPatternService, RegexPatternService>();
builder.Services.AddScoped<ITextProcessingService, TextProcessingService>();
builder.Services.AddScoped<INumberConversionService, NumberConversionService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();

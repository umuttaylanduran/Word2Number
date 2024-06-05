using NLP.API.Services.Abstracts;
using NLP.API.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITextConversionService, TextConversionService>(); // Sýnýfýmýzý, interface'in bir servisi olarak kaydettik.
                                                                             // Instance'ý oluþtururken AddScoped'i tercih ettik. AddScoped her HTTP isteðinde yeni bir instance oluþturur.
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

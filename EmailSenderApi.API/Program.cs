using EmailSenderApi.Application.Interfaces;
using EmailSenderApi.Application.Services;
using EmailSenderApi.Domain.Interfaces;
using EmailSenderApi.Infrastructure;
using EmailSenderApi.Infrastructure.Repositories;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

// Registrar serializador de Guid global (usar antes de qualquer operação com MongoDB)
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

// Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();

// MongoDB
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings")
);

builder.Services.AddSingleton<IMongoContext, MongoContext>();

// Repositories
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

// Services
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
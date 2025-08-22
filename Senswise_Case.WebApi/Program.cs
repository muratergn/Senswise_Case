using Microsoft.EntityFrameworkCore;
using Senswise_Case.Application.Interfaces;
using Senswise_Case.Application.Features.CQRS.Handlers;
using Senswise_Case.Persistence.Context;
using Senswise_Case.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserContext>(opt =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseNpgsql(cs);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<CreateUserCommandHandler>();
builder.Services.AddScoped<GetUserByIdQueryHandler>();
builder.Services.AddScoped<GetUserQueryHandler>();
builder.Services.AddScoped<UpdateUserCommandHandler>();
builder.Services.AddScoped<RemoveUserCommandHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

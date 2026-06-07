using Microsoft.EntityFrameworkCore;
using Notification.Application.Services;
using Notification.Application.Services.Impliments;
using Notification.Application.Services.Interfaces;
using Notification.Domain.Interfaces.Repository;
using Notification.Domain.Interfaces.Unit_of_work;
using Notification.Infrastructure.NotificationContext;
using Notification.Infrastructure.Repositories;
using Notification.Infrastructure.Repository;
using Notification.Infrastructure.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// MassTransit configuration
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<NotificationCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationTemplateRepository, NotificationTemplateRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITemplateEngine, TemplateEngine>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationTemplateService, NotificationTemplateService>();

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

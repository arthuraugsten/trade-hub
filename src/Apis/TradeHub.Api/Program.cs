using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TradeHub.Core.Application;
using TradeHub.Products.Application;
using TradeHub.Products.Application.Repositories;
using TradeHub.Products.Infrastructure;
using TradeHub.Products.Infrastructure.Repositories;
using TradeHub.Products.Presentation.Endpoints.CreateProduct;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(ApplicationAssemblyInfo.Assembly);
    config.AddBehavior(typeof(PipelineRequestValidator<,>));
});

builder.Services.AddValidatorsFromAssembly(ApplicationAssemblyInfo.Assembly);

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ProductsDb"),
        optionsBuilder =>
        {
            optionsBuilder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(20), []);
            optionsBuilder.MigrationsHistoryTable(ProductDbContext.MigrationHistoryTableName, ProductDbContext.SchemaName);
        }
    )
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapProductEndpoint();

app.Run();


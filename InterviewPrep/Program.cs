using InterviewPrep.Application.Dependencies;
using InterviewPrep.Application.Features.Orders.Queries.GetOrder;
using InterviewPrep.Application.Features.Orders.ViewModels;
using InterviewPrep.Application.Products.Commands.CreateProduct;
using InterviewPrep.Application.Products.GetProducts;
using InterviewPrep.Application.ViewModels;
using InterviewPrep.HttpResponses;
using InterviewPrep.Infrastructure;
using MediatR;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Interview Prep",
        Version = "v1",
        Description = "Sample ASP.NET Core Minimal API with Swagger"
    });
});

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()    // ⚠️ Only for development! In production, restrict to your frontend URL
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API v1");
        options.RoutePrefix = string.Empty; // Makes Swagger UI available at root URL
    });
}

app.UseHttpsRedirection();
app.UseCors(); 

app.MapGet("/getproducts", async (IMediator mediator) =>
    {
        var getProductRequest = new GetProductsRequest();
        var result = await mediator.Send(getProductRequest);
        return Results.Ok(result);
    })
    .WithName("GetProducts")
    .Produces<IEnumerable<ReadProductViewModel>>()
    .WithOpenApi(); // Enables metadata for Swagger

app.MapPost("/createproduct", async (CreateProductViewModel product, IMediator mediator) =>
    {
        var createProductCommand = new CreateProductRequest(
            product.ProductDescription,
            product.ProductPrice
            );
        
        var result = await mediator.Send(createProductCommand);
        return Results.Ok(result);
    }).WithName("CreateProduct")
    .Produces<long>()
    .WithOpenApi();

app.MapGet("/getorder", async (long orderId, IMediator mediator) =>
    {
        var result = await mediator.Send(new GetOrderByIdRequest(orderId));
        return result.ToMinimalApiResult();
    })
    .WithName("GetOrder")
    .Produces<ReadOrderViewModel>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status400BadRequest)
    .WithOpenApi();

app.Run();


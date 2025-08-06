
using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record UpdateProductResponse(bool isSuccess);
public class UpdateProductEnpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest resquest, ISender sender) =>
        {

            var command = resquest.Adapt<UpdateProductCommand>();
            var result = await sender.Send(command);
            var resupose = result.Adapt<UpdateProductResponse>();
            return Results.Ok(resupose);
        }).WithName("UpdateProduct")
        .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}


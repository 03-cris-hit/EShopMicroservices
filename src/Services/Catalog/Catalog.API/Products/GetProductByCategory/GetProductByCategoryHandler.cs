
namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string categpry): IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);
internal class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryHandler Called with {@query}", query);
        var products = await session.Query<Product>().Where(p=>p.Category.Contains(query.categpry)).ToListAsync();
        return new GetProductByCategoryResult(products);    
    }
}

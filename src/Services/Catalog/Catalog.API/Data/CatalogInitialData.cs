using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreConfiguredProducts());
            
            await session.SaveChangesAsync();
            
        }

        private static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>{
        
            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },
            
            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            }
            ,
            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            }
            ,

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            },

            new Product(){
                Id= Guid.NewGuid(),
                Name="A",
                Description="DESC",
                Price=10,
                Category = new List<string>{ "Smart"}
            }
        };
    }
}

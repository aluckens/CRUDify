using CRUDy.Repository;
using CRUDyExample.Models;

namespace CRUDyExample.Repository
{
    public interface IProductRepository : ICrudyGenericRepository<Product,long>
    {
    }
}

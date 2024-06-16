using CRUDyExample.Models;
using CRUDy.Repository;
using CRUDyExample.Data;

namespace CRUDyExample.Repository
{
    public class ProductRepositoryImpl : CrudyGenericRepositoryImpl<Product, long>, IProductRepository
    {
        public ProductRepositoryImpl(MyCrudDBContext context) : base(context)
        {
        }
    }
}

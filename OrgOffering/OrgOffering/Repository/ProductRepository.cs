using OrgOffering.Data;
using OrgOffering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(CMPG323Context context) : base(context)
    {
    }

    public void CreateProduct(Product product)
    {
        Create(product);
    }

    public void EditProduct(Product product)
    {
        Update(product);
    }

    public void DeleteProduct(Product product)
    {
        Remove(product);
    }

    public void ExistProduct(Product product)
    {
     //   return Task.FromResult(GenericRepository<Product>.GetProduct(Find()).Orderby);
    //ditnotcomplete
    }

    public Product GetMostRecentProduct()
    {
        return _context.Product.OrderByDescending(product => product.CreatedDate).FirstOrDefault();
    }

    public Product GetProduct(Guid id)
    {
        return Find(p => p.ProductId == id).FirstOrDefault();
    }
}


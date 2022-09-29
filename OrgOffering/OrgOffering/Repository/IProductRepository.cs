using OrgOffering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IProductRepository : IGenericRepository<Product>
{
    Product GetMostRecentProduct();

    Product GetProduct(Guid id);

    void CreateProduct(Product product);

    void EditProduct(Product product);

    void DeleteProduct(Product product);

    void ExistProduct(Product product);


}


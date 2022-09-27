using OrgOffering.Data;
using OrgOffering.Models;
using System.Collections.Generic;
using System.Linq;

public class ProductRepository
{
    protected readonly CMPG323Context _context = new CMPG323Context();

    // GET ALL: Products
    public IEnumerable<Product> GetAll()
    {
        return _context.Product.ToList();
    }

    // TO DO: Add ‘Get By Id’
    // TO DO: Add ‘Create’
    // TO DO: Add ‘Edit’
    // TO DO: Add ‘Delete’
    // TO DO: Add ‘Exists’
}


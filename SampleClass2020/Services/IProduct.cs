using SampleClass2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Services
{
    public interface IProduct
    {
        bool AddProduct(Product model);
        bool UpdateProduct(Product model);
        bool DeleteProduct(Product model);
        ICollection<Product> GetProducts();
        Product GetProductById(int Id);
    }
}

using SampleClass2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Services
{
    public class ProductRepository : IProduct
    {
        private List<Product> _ctx { get; set; }

        public ProductRepository()
        {
            var ctx = new List<Product>
            {
                new Product{ ProdId=1, ProductName="Luxury Ultra thin Wrist Watch", Price=3000, Quantity=40, UserId=1, Photo="~/images/watch.jpg" },
                new Product{ ProdId=2, ProductName="XP 1155 Intel Core Laptop", Price=300000, Quantity=30, UserId=2, Photo="~/images/laptop.jpg" },
                new Product{ ProdId=3, ProductName="EXP Portable Hard Drive", Price=10000, Quantity=50, UserId=2, Photo="~/images/external-hard-drive.jpg" },
                new Product{ ProdId=4, ProductName="FinePix Pro2 3D Camera", Price=35000, Quantity=5, UserId=1, Photo="~/images/camera.jpg" },
            };

            _ctx = ctx;
        }

        public bool AddProduct(Product model)
        {
            _ctx.Add(model);
            return true;
        }

        public bool DeleteProduct(Product model)
        {
            var product = _ctx.FirstOrDefault(x => x.ProdId == model.ProdId);
            if(product != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product GetProductById(int Id)
        {
            return _ctx.FirstOrDefault(x => x.ProdId == Id);
        }

        public ICollection<Product> GetProducts()
        {
            return _ctx;
        }

        public bool UpdateProduct(Product model)
        {
            var product = _ctx.FirstOrDefault(x => x.ProdId == model.ProdId);
            if (product != null)
            {
                product.ProdId = model.ProdId;
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                product.UserId = model.UserId;
                product.DateAdded = model.DateAdded;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

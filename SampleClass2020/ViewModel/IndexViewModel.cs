using SampleClass2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<CartProductsViewModel> CartProducts { get; set; }
        public IEnumerable<Product> CardProducts { get; set; }
        public decimal GrandTotal { get; set; }

        public IndexViewModel()
        {
            CartProducts = new List<CartProductsViewModel>();
            CardProducts = new List<Product>();
        }
    }

    public class CartProductsViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
    }
}

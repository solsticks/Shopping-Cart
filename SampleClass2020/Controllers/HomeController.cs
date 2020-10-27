using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleClass2020.Models;
using SampleClass2020.Services;
using SampleClass2020.ViewModel;

namespace SampleClass2020.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduct _product;
        private readonly ICart _cart;

        public HomeController(ILogger<HomeController> logger, IProduct product, ICart cart)
        {
            _logger = logger;
            _product = product;
            _cart = cart;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            var result = _product.GetProducts();
            ViewBag.Showmenu = false;

            if (model != null)
            {
                model.CardProducts = result;
                model.CartProducts = null;
                return View(model);
            }

            else
                return View("NotFound");
        }


        [HttpPost]
        public IActionResult Index(int Id)
        {
            var allProducts = _product.GetProducts();
            var singleProduct = _product.GetProductById(Id);
            
            var model = new IndexViewModel();

            if (singleProduct != null)
            {
                // add new product to cart
                var productToCart = new Cart
                {
                    ProdId = singleProduct.ProdId,
                    ProdName = singleProduct.ProductName,
                    UnitPrice = singleProduct.Price,
                    AddedBy = 1,
                };

                //**********reduce the card item quantity*************//
                if ((singleProduct.Quantity - 1) >= 0)
                {
                    singleProduct.Quantity -= 1;
                    _product.UpdateProduct(singleProduct);
                    
                    _cart.AddToCart(productToCart);
                }
                //******************************************************//

                
                // get items added by current user
                var result = _cart.GetItemsAddedByUser(1);

                // group items by product and get the quantity and total price
                var quantity = from r in result group r by r.ProdId into newGroup
                                select new { Id = newGroup.Key, qty = newGroup.Count(), 
                                    total = newGroup.Sum(x => x.UnitPrice),
                                };

                var list = new List<CartProductsViewModel>();
                // construct each object with total quantity and total price
                foreach(var item in quantity)
                {
                    var cartModel = new CartProductsViewModel
                    {
                        Id = model.CartProducts.Count() + 1,
                        ProductId = item.Id,
                        ProductName = _product.GetProductById(item.Id).ProductName,
                        Quantity = item.qty, 
                        UnitPrice = _product.GetProductById(item.Id).Price,
                        Price = item.total
                    };
                    list.Add(cartModel);
                }
             
                // add to view model
                model.CardProducts = allProducts;
                model.CartProducts = list;
                model.GrandTotal = quantity.Sum(x => x.total);
                return View(model);
                
            }

            model.CardProducts = allProducts;
            model.CartProducts = null;
            model.GrandTotal = 0;
            return View(model);
        }



        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //There are three service lifetimes in ASP.NET Core Dependency Injection: 
        // unable to resolve ..... while atempting to ...
    }
}

using SampleClass2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Services
{
    public interface ICart
    {
        bool AddToCart(Cart model);
        bool DeleteFromCart(int Id);
        bool DeleteAllFromCart();
        IEnumerable<Cart> GetAllCartItems();
        IEnumerable<Cart> GetItemsAddedByUser(int UserId);

    }
}

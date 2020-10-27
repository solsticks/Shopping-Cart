using SampleClass2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Services
{
    public class CartRepository : ICart
    {
        private List<Cart> _ctx { get; set; }

        public CartRepository()
        {
            _ctx = new List<Cart>();
        }

        public bool AddToCart(Cart model)
        {
            model.Id = _ctx.Count > 0 ? _ctx.Max(x => x.Id) + 1 : 1;

            _ctx.Add(model);
            return true;
        }

        public bool DeleteFromCart(int Id)
        {
            var item = _ctx.FirstOrDefault(x => x.ProdId == Id);
            if(item != null)
            {
                _ctx.Remove(item);
                return true;
            }
            return false;
        }

        public bool DeleteAllFromCart()
        {
            if (_ctx != null)
            {
                _ctx.Clear();
                return true;
            }
            return false;
        }

        public IEnumerable<Cart> GetAllCartItems()
        {
            return _ctx;                         
        }

        public IEnumerable<Cart> GetItemsAddedByUser(int UserId)
        {
            return _ctx.Where(x => x.AddedBy == UserId);
        }

    }
}

using System.Collections.Generic;
using System.Linq;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart() {
            
        }

        public ShoppingCart(string userName) {
            UserName = userName;
        }

        public decimal TotalPrice => Items.Count > 0 
                                         ? Items.Select(i => i.Price * i.Quantity).Sum()
                                         : 0;
    }
}

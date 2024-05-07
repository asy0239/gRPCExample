using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ShoppingCartItem() { }

        public ShoppingCartItem(int id, int productId, Product product, int userId)
        {
            Id = id;
            ProductId = productId;
            Product = product;
            UserId = userId;
        }
    }
}

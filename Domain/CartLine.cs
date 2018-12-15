using Domain.Base;

namespace Domain
{
    public class CartLine : EntityBase
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

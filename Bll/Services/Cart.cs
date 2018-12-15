using System.Collections.Generic;
using System.Linq;
using Dto;

namespace Bll.Services
{
    public class Cart 
        {
        private List<CartLineDto> _cartLineCollection = new List<CartLineDto>();

        public virtual void Add(ProductDto product, int quantity)
        {
            var line = _cartLineCollection
                .Where(l => l.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null) {
                _cartLineCollection.Add(new CartLineDto {
                    Product = product,
                    Quantity = quantity
                });
            } else {
                line.Quantity += quantity;
            }
        }

        public virtual void Remove(ProductDto product) =>
            _cartLineCollection.RemoveAll(l => l.Product.Id == product.Id);

        public virtual decimal ComputeTotalValue() =>
            _cartLineCollection.Sum(l => l.Product.Price * l.Quantity);

        public virtual void Clear() => _cartLineCollection.Clear();

        public virtual IEnumerable<CartLineDto> CartLines => _cartLineCollection;
    }
}

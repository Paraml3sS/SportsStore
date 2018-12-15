using Dto.Base;

namespace Dto
{
    public class CartLineDto : EntityBaseDto
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}

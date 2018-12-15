using System.Collections.Generic;
using Dto;

namespace WebApp.Viewmodels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}

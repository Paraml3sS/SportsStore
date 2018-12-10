﻿using Dto.Base;

namespace Dto
{
    public class ProductDto : EntityBaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}

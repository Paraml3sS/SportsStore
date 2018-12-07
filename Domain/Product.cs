﻿using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}

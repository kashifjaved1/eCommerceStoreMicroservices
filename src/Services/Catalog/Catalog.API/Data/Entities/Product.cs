﻿namespace Catalog.API.Data.Entities
{
    public class Product : NamedEntity
    {
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}

﻿using System.Text.Json.Serialization;

namespace eCommerceBlazorFrontEnd.Models
{
    public class Product
    {        
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}

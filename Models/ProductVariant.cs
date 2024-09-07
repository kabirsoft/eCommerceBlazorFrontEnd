using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eCommerceBlazorFrontEnd.Models
{
    public class ProductVariant
    {
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        public ProductType? ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
    }
}

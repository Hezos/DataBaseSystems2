using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    [Table("productrating")]
    public class ProductRating:IModul
    {
        public ProductRating(string rating, int productId)
        {
            Rating = rating;
            ProductId = productId;
        }
        public ProductRating()
        {

        }
        [Column("rating")]
        [JsonPropertyName("Rating")]
        public string Rating { get; set; }
        [Column("pid")]
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"{Rating}";
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    [Table("Order")]
    public class Order:IModul
    {
        public Order(DateTime orderDate, int customerId, int productId)
        {
            OrderDate = orderDate;
            CustomerId = customerId;
            ProductId = productId;
        }
        public Order()
        {

        }
        [Column("orderdate")]
        [JsonPropertyName("oederdate")]
        public DateTime OrderDate { get; set; }
        [Column("cid")]
        [JsonPropertyName("customerid")]
        public int CustomerId { get; set; }
        [Column("productid")]
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"{OrderDate}";
        }
    }
}

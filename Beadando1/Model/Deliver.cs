using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    [Table("Deliver")]
    public class Deliver:IModul
    {
        public Deliver(int deliveryId, int customerId, string deliveryPlace)
        {
            DeliveryId = deliveryId;
            CustomerId = customerId;
            DeliveryPlace = deliveryPlace;
        }
        public Deliver()
        {

        }
        [Column("did")]
        [JsonPropertyName("DeliveryId")]
        public int DeliveryId { get; set; }
        [Column("cid")]
        [JsonPropertyName("CustomerId")]
        public int CustomerId { get; set; }
        [Column("deliveryplace")]
        [JsonPropertyName("DeliveryPlace")]
        public string DeliveryPlace { get; set; }

        public override string ToString()
        {
            return $"{DeliveryPlace}";
        }
    }
}

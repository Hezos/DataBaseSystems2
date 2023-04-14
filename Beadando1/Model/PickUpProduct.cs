using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    [Table("roductpickup")]
    public class PickUpProduct:IModul
    {
        public PickUpProduct(int ownerId, int deliveryId, string pickUpPlace)
        {
            OwnerId = ownerId;
            DeliveryId = deliveryId;
            PickUpPlace = pickUpPlace;
        }
        public PickUpProduct()
        {

        }
        [Column("oid")]
        [JsonPropertyName("OwnerId")]
        public int OwnerId { get; set; }
        [Column("did")]
        [JsonPropertyName("DeliveryId")]
        public int DeliveryId { get; set; }
        [Column("pickupplace")]
        [JsonPropertyName("PickUpPlace")]
        public string PickUpPlace { get; set; }

        public override string ToString()
        {
            return $"{PickUpPlace}";
        }
    }
}

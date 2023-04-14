using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    [Table("Delivery")]
    public class Delivery:IModul
    {
        public Delivery(int did, DateTime deliveryDate)
        {
            this.did = did;
            this.deliveryDate = deliveryDate;
        }
        public Delivery()
        {

        }

        [PrimaryKey, AutoIncrement, Column("did")]
        [JsonPropertyName("did")]
        public int did { get; set; }
        [Column("delivery_date")]
        [JsonPropertyName("deliveryDate")]
        public DateTime deliveryDate { get; set; }

        public override string ToString()
        {
            return $"{deliveryDate}";
        }
    }
}

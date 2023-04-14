using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    [Table("Upload")]
    public class Upload:IModul
    {
        public Upload(DateTime uploadDate, int ownerId, int productId)
        {
            UploadDate = uploadDate;
            OwnerId = ownerId;
            ProductId = productId;
        }
        public Upload()
        {

        }

        [Column("uploaddate")]
        [JsonPropertyName("UploadDate")]
        public DateTime UploadDate { get; set; }
        [Column("ownerid")]
        [JsonPropertyName("OwnerId")]
        public int OwnerId { get; set; }
        [Column("pid")]
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"{UploadDate}";
        }
    }
}

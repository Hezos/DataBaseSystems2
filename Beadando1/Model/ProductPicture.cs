using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    [Table("product_picture")]
    public class ProductPicture:IModul
    {
        public ProductPicture(int id, int pid)
        {
            Id = id;
            this.pid = pid;
        }
        public ProductPicture()
        {

        }

        [PrimaryKey, AutoIncrement, Column("ppid")]
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [Column("pid")]
        [JsonPropertyName("pid")]
        public int pid { get; set; }

        public override string ToString()
        {
            return $"{Id} {pid}";
        }
    }
}

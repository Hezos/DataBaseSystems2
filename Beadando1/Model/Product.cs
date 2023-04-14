using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    [Table("Product")]
    public class Product:IModul
    {
        public Product(int id, string description)
        {
            Id = id;
            Description = description;
        }
        public Product()
        {

        }

        [PrimaryKey, AutoIncrement, Column("pid")]
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [Column("description")]
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Description}";
        }
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Beadando1.Model
{
    [Table("Customer")]
    public class Customer:IModul
    {
        public Customer(int id, string firstName, string lastName, int address, int houseNumber, string street, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            HouseNumber = houseNumber;
            Street = street;
            City = city;
        }
        public Customer()
        {

        }

        [PrimaryKey, AutoIncrement, Column("cid")]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Column("firstname")]
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [Column("lastname")]
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [Column("address")]
        [JsonPropertyName("Address")]
        public int Address { get; set; }
        [Column("housenumber")]
        [JsonPropertyName("HouseNumber")]
        public int HouseNumber { get; set; }
        [Column("street")]
        [JsonPropertyName("Street")]
        public string Street { get; set; }
        [Column("city")]
        [JsonPropertyName("City")]
        public string City { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Address} {City} {Street} {HouseNumber}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SQLite;

namespace Beadando1.Model
{
    [Table("Owner")]
    public class Owner:IModul
    {
        public Owner(int id, DateTime birthDate, string firstname, string lastname, int housenumber, int address, string city, string street, int did)
        {
            Id = id;
            BirthDate = birthDate;
            this.firstname = firstname;
            this.lastname = lastname;
            this.housenumber = housenumber;
            this.address = address;
            this.city = city;
            this.street = street;
            this.did = did;
        }
        public Owner()
        {

        }


        [PrimaryKey, AutoIncrement, Column("id")]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Column("date_of_birth")]
        [JsonPropertyName("BirthDate")]
        public DateTime BirthDate { get; set; }
        [Column("firstname")]
        [JsonPropertyName("firstname")]
        public string firstname { get; set; }
        [Column("lastname")]
        [JsonPropertyName("lastname")]
        public string lastname { get; set; }
        [Column("house_number")]
        [JsonPropertyName("housenumber")]
        public int housenumber { get; set; }
        [Column("address")]
        [JsonPropertyName("address")]
        public int address { get; set; }
        [Column("city")]
        [JsonPropertyName("city")]
        public string city { get; set; }
        [Column("street")]
        [JsonPropertyName("street")]
        public string street { get; set; }
        [SQLite.Unique, Column("did")]
        [JsonPropertyName("did")]
        public int did { get; set; }

        public override string ToString()
        {
            return $"{lastname} {firstname} {BirthDate} {address} {city} {street} {housenumber}";
        }
    }
}

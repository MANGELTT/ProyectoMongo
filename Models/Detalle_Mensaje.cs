using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ProyectoMongo.Models
{
    public class Detalle_Mensaje
    {
        //[BsonElement ("NumeroTelefono")]
        //public string NumeroTelefono { get; set;}

        //[BsonElement ("Compania")]
        //public string Compania { get; set;}

        //[BsonElement("Mensaje")]
        //public string Mensaje { get; set;}

        [BsonElement("NumeroTelefono")]
        public long NumeroTelefono { get; set; }

        [BsonElement("Compania")]
        public string Compania { get; set; }

        [BsonElement("Mensaje")]
        public string Mensaje { get; set; }
    }
}
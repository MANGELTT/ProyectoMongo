﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ProyectoMongo.Models
{
    public class Mensajes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("idTelefono")]
        public int idTelefono { get; set; }

        public Detalle_Mensaje[] DetallesM { get; set; }
    }
}

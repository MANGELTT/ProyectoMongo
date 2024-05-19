using MongoDB.Bson;
using MongoDB.Driver;
using ProyectoMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProyectoMongo
{
    internal class ConectarMondoDB
    {
        private MongoClient client;
        private IMongoDatabase database;

        public IMongoCollection<Mensajes> MensajesCollection { get; }

        public ConectarMondoDB()
        {
            //client = new MongoClient("mongodb://localhost:27017");
            client = new MongoClient("mongodb+srv://202310291:NAzAtFajoQNVgguY@bd-teltec.6vuhjjc.mongodb.net/");
            database = client.GetDatabase("BD_TelTec");
            MensajesCollection = database.GetCollection<Mensajes>("Mensajes");

        }
    }
}

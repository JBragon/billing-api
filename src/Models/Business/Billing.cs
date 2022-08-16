using Models.Infrastructure;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Models.Business
{
    public class Billing
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CPF { get; set; }
        public DateTime DueDate { get; set; }
        public decimal ChargeAmount { get; set; }
    }

}

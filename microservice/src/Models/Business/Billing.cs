using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

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

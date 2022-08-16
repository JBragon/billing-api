using DataAccess.Config;
using Models.Business;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace DataAccess.Context
{
    public class MongoDbContext
    {
        public readonly IMongoCollection<Billing> Billings;

        public MongoDbContext(IBillingDatabaseSettings settings)
        {
            var client = GetClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatbaseName);

            Billings = database.GetCollection<Billing>(settings.CollectionName);
        }

        private MongoClient GetClient(string connectionString)
        {
            if (connectionString.Contains("localhost"))
            {
                return new MongoClient(connectionString);
            }

            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            return new MongoClient(settings);
        }
    }
}

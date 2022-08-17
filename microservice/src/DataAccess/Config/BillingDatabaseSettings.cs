namespace DataAccess.Config
{
    public class BillingDatabaseSettings : IBillingDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

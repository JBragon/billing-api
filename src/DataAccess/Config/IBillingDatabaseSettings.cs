namespace DataAccess.Config
{
    public interface IBillingDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatbaseName { get; set; }
    }
}
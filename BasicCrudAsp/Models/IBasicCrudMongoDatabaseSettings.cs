namespace BasicCrudAsp.Models
{
    public interface IBasicCrudMongoDatabaseSettings
    {
        string GamesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
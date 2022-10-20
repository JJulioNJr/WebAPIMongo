namespace WebAPIMongo.Utils {
    public interface IDatabaseSettings {

        string ClientCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}

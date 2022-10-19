namespace WebAPIMongo.Utils {
    public interface IDataBaseSettings {

        string ClientCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DataBaseName { get; set; }
    }
}

namespace WebAPIMongo.Utils {
    public class DataBaseSettings : IDataBaseSettings {
        public string ClientCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string ConnectionString { get ; set ; }
        public string DataBaseName { get; set ; }
    }
}

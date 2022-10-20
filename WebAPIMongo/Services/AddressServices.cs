using MongoDB.Driver;
using System;
using System.Collections.Generic;
using WebAPIMongo.Models;
using WebAPIMongo.Utils;

namespace WebAPIMongo.Services
{
    public class AddressServices
    {

        private readonly IMongoCollection<Address> _address;

        public AddressServices(IDatabaseSettings settings)
        {

            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DataBaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);

        }

        internal Address Create(Address address) {
            _address.InsertOne(address);
            return address;
        }

        public List<Address> Get() => _address.Find<Address>(adress => true).ToList();
        public Address Get(string id) => _address.Find<Address>(address => address.Id == id).FirstOrDefault();
        public void Update(string id, Address addressIn) {
            _address.ReplaceOne(address => address.Id == id, addressIn);
        }
        public void Remove(Address addressIn) => _address.DeleteOne(address => address.Id == addressIn.Id);
    }
}

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using WebAPIMongo.Models;
using WebAPIMongo.Utils;

namespace WebAPIMongo.Services {
    public class ClientServices  {



        private readonly IMongoCollection<Client> _clients;
        private readonly IMongoCollection<Address> _adress;

        public ClientServices(IDataBaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString); 
            var database = client.GetDatabase(settings.DataBaseName);
            _clients = database.GetCollection<Client>(settings.ClientCollectionName);

        }

        public Client Create(Client client) {
            _clients.InsertOne(client);
            return client;
        }
        
        public List<Client> Get() => _clients.Find<Client>(client => true).ToList();
        public Client Get(string id) => _clients.Find<Client>(client => client.Id == id).FirstOrDefault();
        public void Update(string id, Client clientIn) {
            _clients.ReplaceOne(client => client.Id == id,clientIn);
        }
        public void Remove(Client clientIn) => _clients.DeleteOne(client => client.Id == clientIn.Id);

        























    }
}

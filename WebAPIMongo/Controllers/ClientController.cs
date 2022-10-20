
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIMongo.Models;
using WebAPIMongo.Services;

namespace WebAPIMongo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {

        private readonly ClientServices _clientService;
        private readonly AddressServices _addressServices;
        public ClientController(ClientServices clientService,AddressServices addressServices) {

            _clientService=clientService;
            _addressServices = addressServices;

        }
        [HttpGet]
        public ActionResult<List<Client>>Get() => _clientService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id) {
            var client=_clientService.Get(id);
            if (client == null) {
                return NotFound();
            } else {
                return Ok(client);
            }
        }
        [HttpGet("Name", Name = "GetClientName")]
        public ActionResult<Client> GetName(string name) {
            var client = _clientService.GetName(name);
            if (client == null) {
                return NotFound();
            } else {
                return Ok(client);
            }
        }

        [HttpGet("Address/{id:length(24)}/", Name = "GetClientAddress")]
        public ActionResult<Client> GetAddress(string id) {
            var client = _clientService.GetAddress(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }


        
            [HttpPost]
        public ActionResult<Client> Create(Client client) {

            Address address = _addressServices.Create(client.Address);
            client.Address = address;

            _clientService.Create(client);
            return CreatedAtRoute("GetClient", new {id=client.Id.ToString()},client);
        }

        [HttpPut]
        public ActionResult<Client> Update(string id, Client clientIn) {

          var client =  _clientService.Get(id);
            if (client == null) {
                return NotFound();
            } else {
                _clientService.Update(id, clientIn);
                client=_clientService.Get(id);
            }
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(string id) {
            var client = _clientService.Get(id);
            if (client == null) {
                return NotFound();
            } else {
                _clientService.Remove(client);
               // client = _clientService.Get(id);
            }
            return NoContent();

        }












    }
}

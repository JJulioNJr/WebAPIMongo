using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WebAPIMongo.Models;
using WebAPIMongo.Services;

namespace WebAPIMongo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase {

        private readonly AddressServices _addressService;
        private readonly ClientServices _clientService;

        public AddressController(AddressServices addressService,ClientServices clientService) {
            _addressService = addressService;
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id) {
            var address = _addressService.Get(id);
            if (address == null) {
                return NotFound();
            } else {
                var client = _clientService.Get();
                var c=client.FirstOrDefault(x => x.Address.Id == id);
              



                return Ok(address);
            }
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address) {

            _addressService.Create(address);
            return CreatedAtRoute("GetAddress", new { id = address.Id.ToString() }, address);
        }

        [HttpPut]
        public ActionResult<Client> Update(string id, Address addressIn) {

            var address = _addressService.Get(id);
            if (address == null) {
                return NotFound();
            } else {
                _addressService.Update(id, addressIn);
                address = _addressService.Get(id);
            }
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(string id) {
            var address = _addressService.Get(id);
            if (address == null) {
                return NotFound();
            } else {
                _addressService.Remove(address);
                
            }
            return NoContent();

        }

    }
}

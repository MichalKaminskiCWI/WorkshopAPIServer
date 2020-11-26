using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopAPIServer.Models;
using WorkshopAPIServer.Services;

namespace WorkshopAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlienciController : ControllerBase
    {
        private readonly IMongoRepository<Klient> _klienciRepository;

        public KlienciController(IMongoRepository<Klient> klienciRepository)
        {
            _klienciRepository = klienciRepository;
        }

        [HttpGet]
        public ActionResult<List<Klient>> Get() =>
            _klienciRepository.Get();

        [HttpGet("{id:length(24)}", Name = "GetKlient")]
        public ActionResult<Klient> Get(string id)
        {
            var klient = _klienciRepository.Get(id);

            if (klient == null)
            {
                return NotFound();
            }

            return klient;
        }


        [HttpPost]
        public ActionResult<Klient> Create(Klient klient)
        {
            _klienciRepository.Create(klient);

            return CreatedAtRoute("GetKlient", new { id = klient.Id }, klient);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Klient klientIn)
        {
            var klient = _klienciRepository.Get(id);

            if (klient == null)
            {
                return NotFound();
            }

            _klienciRepository.Update(id, klientIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var klient = _klienciRepository.Get(id);

            if (klient == null)
            {
                return NotFound();
            }

            _klienciRepository.Remove(klient.Id);

            return NoContent();
        }


    }
}

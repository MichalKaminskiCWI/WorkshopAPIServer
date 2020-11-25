using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopAPIServer.Models;
using WorkshopAPIServer.Services;

namespace WorkshopAPIServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly IMongoRepository<Klient> _klientRepository;

        public SampleController(IMongoRepository<Klient> klientRepository)
        {
            _klientRepository = klientRepository;
        }

        [HttpPost("registerKlient")]
        public async Task AddKlient(string firstName, string lastName)
        {
            var person = new Klient()
            {
                Imie = "John",
                Nazwisko = "Doe"
            };

            await _klientRepository.InsertOneAsync(person);
        }


        [HttpGet("getKlientData")]
        public IEnumerable<string> GetKlientData()
        {
            var klienci = _klientRepository.FilterBy(
                filter => filter.KodPocztowy == null,
                projection => projection.Imie
            );
            return klienci;
        }

    }
}

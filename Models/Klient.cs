using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkshopAPIServer.Models
{
    [BsonCollection("Klient")]
    public class Klient: Document
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public string NrDomu { get; set; }
        public string NrMieszkania { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public string NrKontaktowyTel { get; set; }
        public string Email { get; set; }




    }

}


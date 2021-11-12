using System;
using System.Collections.Generic;

#nullable disable

namespace Mazzoni.Alex._5H.Scaffolding.Models
{
    public partial class Studente
    {
        public long Id { get; set; }
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public long FkIdclasse { get; set; }
    }
}

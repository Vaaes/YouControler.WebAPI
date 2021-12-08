using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouControler.WebAPI.Model
{
    public class Candidatos
    {
        public int Id { get; set; }
        public string NomeCandidato { get; set; }
        public int IdadeCandidato { get; set; }
        public string EmailCandidato { get; set; }
        public string TelefoneCandidato { get; set; }
        public int IdVaga { get; set; }
        public string NomeVaga { get; set; }
    }
}

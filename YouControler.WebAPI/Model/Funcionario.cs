using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouControler.WebAPI.Model
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string Salario { get; set; }
        public int IdCargo { get; set; }
    }
}

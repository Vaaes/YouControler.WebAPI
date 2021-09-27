using System;

namespace YouControler.WebAPI.Model
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public string Telefone_Celular { get; set; }
        public string Telefone_Residencial { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Endereco_Rua { get; set; }
        public string Endereco_Numero { get; set; }
        public string Endereco_Bairro { get; set; }
        public string Endereco_Cidade { get; set; }
        public string Endereco_Estado { get; set; }
        public string Estado_Civil { get; set; }
        public int Filhos { get; set; }
        public string Qnt_Filhos { get; set; }
        public string Escolaridade { get; set; }
        public string Departamento { get; set; }
        public int Ativo { get; set; }
        public string Salario { get; set; }

    }
}

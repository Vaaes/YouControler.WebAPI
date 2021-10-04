using System;

namespace YouControler.WebAPI.Model
{
    public class Colaborador
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public string Departamento { get; set; }
        public string Tipo { get; set; }
        public string Gestorimediato { get; set; }
    }

    public class CLT
    {
        public int Id { get; set; }
        public int IdCargo { get; set; }
        public int IdDepartamento { get; set; }
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
        public DateTime DataInicio { get; set; }
        public string Situacao { get; set; }
        public string Salario { get; set; }
        public string Nome_Banco { get; set; }
        public string Agencia_Banco { get; set; }
        public string Conta_Banco { get; set; }
        public string Superior_imediato { get; set; }
        public DateTime Horario { get; set; }
        public string ConsultaProcessual { get; set; }
        public string AntecedentesCriminais { get; set; }
        public string Serasa { get; set; }
        public string QualificacaoCadastral { get; set; }
        public string ConvenioMedico { get; set; }
        public string ConvenioOndotologico { get; set; }
        public string ConvenioFarmacia { get; set; }
        public string ValeRefeicao { get; set; }
        public string ValorVR { get; set; }
        public string ValeAlimetacao { get; set; }
        public string ValorAL { get; set; }
        public string ValeTransporte { get; set; }
        public string TipoTransporte { get; set; }
        public string ValorTransporte { get; set; }
    }
}

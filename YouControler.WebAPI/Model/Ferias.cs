﻿using System;

namespace YouControler.WebAPI.Model
{
    public class Ferias
    {
        public int Id { get; set; }
        public string Data_Inicio { get; set; }
        public string Data_Final { get; set; }
        public int IdUsuario { get; set; }
        public bool Aprovado { get; set; }
        public string Nome { get; set; }
        public int Aprovacao { get; set; }
    }
}

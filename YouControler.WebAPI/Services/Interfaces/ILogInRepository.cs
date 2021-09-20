using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouControler.WebAPI.Model;

namespace YouControler.WebAPI.Services.Interfaces
{
    public interface ILogInRepository
    {
        ValueTask<Usuario> VerificaAcesso(string username, string password);
    }
}

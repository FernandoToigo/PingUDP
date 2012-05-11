using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoPingUDP.Model
{
    public class PingSemRespostaException : Exception
    {
        public PingSemRespostaException(string mensagem)
            : base(mensagem)
        {
        }
    }
}

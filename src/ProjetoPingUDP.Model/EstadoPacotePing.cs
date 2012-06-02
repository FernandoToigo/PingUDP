using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoPingUDP.Model
{
    public enum EstadoPacotePing
    {
        NaoEnviado = 1,
        Enviado = 2,
        Recebido = 4,
        Perdido = 8
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoPingUDP.Model
{
    public enum EstadoPing
    {
        NaoEnviado,
        AguardandoResposta,
        SemResposta,
        Sucesso
    }
}

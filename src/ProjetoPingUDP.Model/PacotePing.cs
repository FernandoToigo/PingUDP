using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoPingUDP.Model
{
    public class PacotePing
    {
        public int Bytes { get; set; }
        public TimeSpan Tempo { get; set; }
        public EstadoPacotePing Estado { get; set; }

        public PacotePing()
        {
            Estado = EstadoPacotePing.NaoEnviado;
        }

        public override string ToString()
        {
            string res = "";

            return res;
        }
    }
}

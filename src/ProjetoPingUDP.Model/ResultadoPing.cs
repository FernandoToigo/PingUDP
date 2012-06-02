using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoPingUDP.Model
{
    public class ResultadoPing
    {
        public int PacotesEnviados
        {
            get
            {
                if (Pacotes != null)
                    return Pacotes.Count(p => (p.Estado & EstadoPacotePing.Enviado) == EstadoPacotePing.Enviado);
                else
                    return 0;
            }
        }
        public int PacotesRecebidos
        {
            get
            {
                if (Pacotes != null)
                    return Pacotes.Count(p => (p.Estado & EstadoPacotePing.Recebido) == EstadoPacotePing.Recebido);
                else
                    return 0;
            }
        }
        public int PacotesPerdidos
        {
            get
            {
                if (Pacotes != null)
                    return Pacotes.Count(p => (p.Estado & EstadoPacotePing.Perdido) == EstadoPacotePing.Perdido);
                else
                    return 0;
            }
        }

        public List<PacotePing> Pacotes { get; set; }

        public ResultadoPing()
        {
            Pacotes = new List<PacotePing>();
        }

        public ResultadoPing(List<PacotePing> pacotes)
        {
            this.Pacotes = pacotes;
        }

        public void AdicionarPacotePing(PacotePing pacote)
        {
            Pacotes.Add(pacote);
        }

        public override string ToString()
        {
            var res = "Pacotes: Enviados = {0}, Recebidos = {1}, Perdidos = {2}\nTempo: Mínimo: {3}ms, Máximo: {4}ms, Média: {5}ms";
            
            var media = (int)Pacotes.Average(p => (int)p.Tempo.TotalMilliseconds);
            var min = Pacotes.Min(p => (int)p.Tempo.TotalMilliseconds);
            var max = Pacotes.Max(p => (int)p.Tempo.TotalMilliseconds);

            return string.Format(res, PacotesEnviados, PacotesRecebidos, PacotesPerdidos, min, max, media);
        }
    }
}

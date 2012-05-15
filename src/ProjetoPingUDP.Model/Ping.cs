using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace ProjetoPingUDP.Model
{
    public class Ping
    {
        private string ipOrigem;
        public string IPOrigem
        {
            get { return ipOrigem; }
            set { ipOrigem = value; }
        }

        private string ipDestino;
        public string IPDestino
        {
            get { return ipDestino; }
            set { ipDestino = value; }
        }

        private int portaDestino;
        public int PortaDestino
        {
            get { return portaDestino; }
            set { portaDestino = value; }
        }

        private EstadoPing estado;
        public EstadoPing Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private bool enviado;
        public bool Enviado
        {
            get { return enviado; }
            set { enviado = value; }
        }

        private int numeroSequencia;
        public int NumeroSequencia
        {
            get { return numeroSequencia; }
            set { numeroSequencia = value; }
        }

        private DateTime dataEnvio;
        public DateTime DataEnvio
        {
            get { return dataEnvio; }
            set { dataEnvio = value; }
        }

        public Ping()
        {
            ipDestino = string.Empty;
            portaDestino = 0;
            estado = EstadoPing.NaoEnviado;
            enviado = false;
            numeroSequencia = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace ProjetoPingUDP.Model
{
    public delegate void PingUdpLogEventHandler(object sender, LogEventArgs e);

    public class LogEventArgs : EventArgs
    {
        public string Log;

        public LogEventArgs(string log)
        {
            this.Log = log;
        }
    }

    public class PingUdp
    {
        public event PingUdpLogEventHandler OnLog;

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

        private bool executado;
        public bool Executado
        {
            get { return executado; }
            set { executado = value; }
        }

        private int numeroPacotes;
        public int NumeroPacotes
        {
            get { return numeroPacotes; }
            set { numeroPacotes = value; }
        }

        public ResultadoPing Executar()
        {
            this.Executado = true;
            IPEndPoint ep = null;
            var resultado = new ResultadoPing();
            var udpClient = new UdpClient(IPDestino, PortaDestino);
            var bytesEnviados = Encoding.ASCII.GetBytes("PING");
            Log(string.Format("Enviando PING para [{0}] através da porta [{1}]:", IPDestino, PortaDestino));

            for (int i = 0; i < numeroPacotes; i++)
            {
                var pacotePing = new PacotePing();
                pacotePing.Bytes = 4;
                pacotePing.Estado = EstadoPacotePing.Enviado;
                try
                {
                    var dataInicio = DateTime.Now;
                    udpClient.Send(bytesEnviados, bytesEnviados.Length);
                    udpClient.Client.ReceiveTimeout = 1000;
                    var bytesRecebidos = udpClient.Receive(ref ep);
                    var dataFim = DateTime.Now;
                    var retorno = Encoding.ASCII.GetString(bytesRecebidos);

                    if (retorno == "PING")
                    {
                        pacotePing.Estado = pacotePing.Estado | EstadoPacotePing.Recebido;
                        pacotePing.Tempo = dataFim - dataInicio;

                        Log(string.Format("Resposta: bytes={0} tempo={1}ms.", pacotePing.Bytes, (int)pacotePing.Tempo.TotalMilliseconds));
                    }
                }
                catch (SocketException)
                {
                    pacotePing.Estado = pacotePing.Estado | EstadoPacotePing.Perdido;
                    Log("Esgotado o tempo limite do pedido.");
                }

                resultado.AdicionarPacotePing(pacotePing);
            }

            return resultado;
        }

        private void Log(string mensagem)
        {
            if (OnLog != null)
                OnLog(this, new LogEventArgs(mensagem));
        }
    }
}

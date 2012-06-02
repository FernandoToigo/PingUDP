using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ProjetoPingUDP.Model
{
    public class ServidorPingUdp : IDisposable
    {
        public int Porta { get; set; }

        private bool ativo;
        public bool Ativo
        {
            get { return ativo; }
        }

        private Thread _threadServidor;

        public void Iniciar()
        {
            _threadServidor = new Thread(ExecutarProcessoServidor);
            _threadServidor.IsBackground = true;
            ativo = true;
            _threadServidor.Start();
        }

        public void Parar()
        {
            if (_threadServidor != null)
            {
                ativo = false;
                _threadServidor.Join();
            }
        }

        private void ExecutarProcessoServidor()
        {
            var udpClient = new UdpClient(Porta);
            udpClient.Client.ReceiveTimeout = 1000;

            while (ativo)
            {
                IPEndPoint ep = null;
                var retorno = string.Empty;
                try
                {
                    var bytesRecebidos = udpClient.Receive(ref ep);
                    retorno = Encoding.ASCII.GetString(bytesRecebidos);

                    try
                    {
                        if (retorno == "PING")
                        {
                            var bytesEnvio = Encoding.ASCII.GetBytes("PING");
                            udpClient.Send(bytesEnvio, bytesEnvio.Length, ep);
                        }
                    }
                    catch (SocketException)
                    {
                        // TODO: tratar falha no envio do retorno do ping
                    }
                }
                catch (SocketException)
                {
                    // TODO: tratar falha no recebimento do ping
                }
            }
        }

        public void Dispose()
        {
            this.Parar();
        }
    }
}

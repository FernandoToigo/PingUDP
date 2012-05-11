using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ProjetoPingUDP.Model
{
    public class GerenciadorUdp
    {
        private UdpClient client;

        public GerenciadorUdp(int portaRecebimento)
        {
            client = new UdpClient(portaRecebimento);
        }

        public void Enviar(string dados, string ipDestino, int portaDestino)
        {
            this.Enviar(Encoding.ASCII.GetBytes(dados), ipDestino, portaDestino);
        }

        public void Enviar(byte[] dados, string ipDestino, int portaDestino)
        {
            UdpClient clientEnvio = new UdpClient();
            clientEnvio.Send(dados, dados.Length, new IPEndPoint(IPAddress.Parse(ipDestino), portaDestino));
            clientEnvio.Close();
        }

        public Ping ReceberPing(int timeout)
        {
            client.Client.ReceiveTimeout = timeout;
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            byte[] dadosRetorno = client.Receive(ref ep);
            string retorno = Encoding.ASCII.GetString(dadosRetorno);
            Ping ping = new Ping();
            if (Regex.IsMatch(retorno, "PING [0-9] [0-9]{14} \r\n"))
            {
                ping.NumeroSequencia = int.Parse(retorno.Substring(5, 1));
                ping.DataEnvio = DateTime.ParseExact(retorno.Substring(7, 14), "ddMMyyyyHHssmm", CultureInfo.InvariantCulture);
            }

            ping.IPOrigem = ep.Address.ToString();
            ping.PortaDestino = ep.Port;
            ping.Estado = EstadoPing.Sucesso;
                
            return ping;
        }

        public void Finalizar()
        {
            client.Close();
        }
    }
}

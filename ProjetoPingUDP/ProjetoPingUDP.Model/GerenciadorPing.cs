using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace ProjetoPingUDP.Model
{
    public class GerenciadorPing
    {
        private GerenciadorUdp gerenciador;
        private Thread threadRecebimento;

        private bool servidorAtivo;
        public bool ServidorAtivo
        {
            get { return servidorAtivo; }
            set { servidorAtivo = value; }
        }

        private int portaRecebimento;
        public int PortaRecebimento
        {
            get { return portaRecebimento; }
            set { portaRecebimento = value; }
        }

        public GerenciadorPing(int porta)
        {
            servidorAtivo = false;
            threadRecebimento = new Thread(ExecutarProcessoServidor);
            portaRecebimento = porta;
        }

        public Ping ExecutarPing(Ping ping)
        {
            gerenciador = new GerenciadorUdp(portaRecebimento);

            this.EnviarPing(ping);

            Ping pingResposta = null;
            try
            {
                pingResposta = gerenciador.ReceberPing(1000);
                ping.Estado = EstadoPing.Sucesso;
            }
            catch
            {
                ping.Estado = EstadoPing.SemResposta;
                throw new PingSemRespostaException("Não houve resposta do Ping!");
            }
            finally
            {
                gerenciador.Finalizar();
            }

            return pingResposta;
        }

        public void IniciarServidor()
        {
            servidorAtivo = true;
            threadRecebimento.Start();
        }

        private void ExecutarProcessoServidor()
        {
            TextWriter tw = new StreamWriter("c:\\temp\\log.txt", true);

            gerenciador = new GerenciadorUdp(portaRecebimento);

            tw.WriteLine(DateTime.Now + " - Iniciando leitura de pacotes na porta " + portaRecebimento + "...\n");

            while (servidorAtivo)
            {
                try
                {
                    Ping ping = gerenciador.ReceberPing(1000);

                    tw.WriteLine(DateTime.Now + " - Respondendo Ping - Origem: {0} Número de Sequência: {1}", ping.IPOrigem, ping.NumeroSequencia);

                    Ping pingResposta = new Ping();
                    pingResposta.IPDestino = ping.IPOrigem;
                    pingResposta.IPOrigem = ping.IPDestino;
                    pingResposta.PortaDestino = 8522;
                    pingResposta.NumeroSequencia = ping.NumeroSequencia;

                    this.EnviarPing(pingResposta);
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    tw.WriteLine(DateTime.Now + " - Sem Resposta: {0} ({1}) ({2}) ({3})", ex.Message.Replace('\n', ' '), ex.SocketErrorCode, ex.NativeErrorCode, ex.ErrorCode);
                }

                Thread.Sleep(100);
            }

            gerenciador.Finalizar();
            tw.Flush();
            tw.Close();
            tw.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void PararEntradaPacotes()
        {
            if (servidorAtivo == true)
            {
                servidorAtivo = false;
                threadRecebimento.Join();
            }
        }

        private void EnviarPing(Ping ping)
        {
            ping.DataEnvio = DateTime.Now;
            gerenciador.Enviar(string.Format("PING {0} {1} \r\n", ping.NumeroSequencia, ping.DataEnvio.ToString("ddMMyyyyHHssmm")), ping.IPDestino, ping.PortaDestino);
            ping.Estado = EstadoPing.AguardandoResposta;
            ping.Enviado = true;
        }
    }
}

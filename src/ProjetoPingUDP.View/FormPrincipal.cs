using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjetoPingUDP.Model;
using System.Threading;
using System.Net.Sockets;

namespace ProjetoPingUDP.View
{
    public partial class FormPrincipal : Form
    {
        GerenciadorPing gerenciadorServidor;
        GerenciadorPing gerenciadorCliente;
        public delegate void AdicionarLogPingDelegate(string log);
        public AdicionarLogPingDelegate adicionarLogPingDelegate;

        public FormPrincipal()
        {
            InitializeComponent();
            adicionarLogPingDelegate = new AdicionarLogPingDelegate(AdicionarLogPing);
        }

        private void buttonExecutarPing_Click(object sender, EventArgs e)
        {
            this.listBoxLogPing.Items.Clear();

            Thread thread = new Thread(delegate()
                                        {
                                            EnviarPings(textBoxIPDestino.Text, int.Parse(textBoxPortaDestino.Text));
                                        });

            thread.Start();
        }

        private void EnviarPings(string ipDestino, int portaDestino)
        {
            try
            {
                if (gerenciadorCliente == null)
                    gerenciadorCliente = new GerenciadorPing(8522);

                for (int i = 0; i < 10; i++)
                {
                    Ping ping = new Ping();
                    ping.NumeroSequencia = i;
                    ping.IPDestino = ipDestino;
                    ping.PortaDestino = portaDestino;
                    ping.Estado = EstadoPing.NaoEnviado;

                    try
                    {
                        this.Invoke(adicionarLogPingDelegate, new object[] { string.Format("Executando Ping. Número de Sequência: {0}", ping.NumeroSequencia) });

                        Ping pingResposta = gerenciadorCliente.ExecutarPing(ping);

                        this.Invoke(adicionarLogPingDelegate, new object[] { string.Format("Ping respondido. Número de Sequência: {0} Data envio: {1}", pingResposta.NumeroSequencia, pingResposta.DataEnvio.ToString("dd/MM/yyyy HH:mm:ss")) });
                    }
                    catch (PingSemRespostaException ex)
                    {
                        this.Invoke(adicionarLogPingDelegate, new object[] { "Ping sem resposta." });
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Não foi possível executar o ping!\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarLogPing(string log)
        {
            listBoxLogPing.Items.Add(log);
        }

        private void buttonIniciarServidor_Click(object sender, EventArgs e)
        {
            try
            {
                int portaServidor = int.Parse(textBoxPortaServidor.Text);
                gerenciadorServidor = new GerenciadorPing(portaServidor);
                gerenciadorServidor.IniciarServidor();

                buttonIniciarServidor.Enabled = false;
                buttonPararServidor.Enabled = true;
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Não foi possível executar o ping!\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.PararServidor();
        }

        private void buttonPararServidor_Click(object sender, EventArgs e)
        {
            this.PararServidor();
        }

        private void PararServidor()
        {
            if (gerenciadorServidor != null)
            {
                buttonPararServidor.Enabled = false;

                gerenciadorServidor.PararEntradaPacotes();

                buttonIniciarServidor.Enabled = true;
            }
        }
    }
}

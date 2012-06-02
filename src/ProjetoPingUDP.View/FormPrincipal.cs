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
        ServidorPingUdp servidor;
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
            PingUdp ping = new PingUdp();
            ping.IPDestino = ipDestino;
            ping.PortaDestino = portaDestino;
            ping.NumeroPacotes = (int)numericUpDownNumeroPacotes.Value;
            ping.OnLog += new PingUdpLogEventHandler(ping_OnLog);
            var resultado = ping.Executar();
            var array = resultado.ToString().Split('\n');

            this.Invoke(adicionarLogPingDelegate, new object[] { array[0] });
            this.Invoke(adicionarLogPingDelegate, new object[] { array[1] });
        }

        void ping_OnLog(object sender, LogEventArgs e)
        {
            this.Invoke(adicionarLogPingDelegate, new object[] { e.Log });
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
                servidor = new ServidorPingUdp();
                servidor.Porta = portaServidor;
                servidor.Iniciar();

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
            if (servidor != null)
            {
                buttonPararServidor.Enabled = false;

                servidor.Parar();

                buttonIniciarServidor.Enabled = true;
            }
        }
    }
}

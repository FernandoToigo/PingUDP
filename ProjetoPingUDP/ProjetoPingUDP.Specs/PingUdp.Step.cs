using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ProjetoPingUDP.Model;
using SharpTestsEx;

namespace ProjetoPingUDP.Specs
{
    [Binding]
    public class PingUdpStep
    {
        GerenciadorPing gerenciadorCliente = new GerenciadorPing(8522);
        GerenciadorPing gerenciadorServidor;
        Ping ping = new Ping(), pingResposta;

        [Given(@"que informei (.*) como IP do destino")]
        public void DadoQueInformeiUmIPComoIPDoDestino(string ipDestino)
        {
            ping.IPDestino = ipDestino;
            ping.IPDestino.Should().Be(ipDestino);
        }

        [Given(@"que informei (.*) como porta do destino")]
        public void DadoQueInformeiUmaPortaComoPortaDoDestino(int portaDestino)
        {
            ping.PortaDestino = portaDestino;
            ping.PortaDestino.Should().Be(portaDestino);
        }

        [Then(@"o pacote Ping deverá ser enviado para o servidor destino")]
        public void EntaoOPacotePingDeveraSerEnviadoParaOServidorDestino()
        {
            ping.Estado.Should().Not.Be(EstadoPing.NaoEnviado);
        }

        [Then(@"deverei receber um pacote Ping de resposta com as informações da rede")]
        public void EntaoDevereiReceberUmPacotePingDeRespostaComAsInformacoesDaRede()
        {
            ping.Estado.Should().Be(EstadoPing.Sucesso);
            pingResposta.Should().Not.Be(null);
        }

        [Then(@"não deverei receber um pacote Ping de resposta com as informações da rede")]
        public void EntaoNaoDevereiReceberUmPacotePingDeRespostaComAsInformacoesDaRede()
        {
            ping.Estado.Should().Be(EstadoPing.SemResposta);
            pingResposta.Should().Be(null);
        }

        [When(@"eu clicar em ""Enviar Ping""")]
        public void QuandoEuClicarEmEnviarPing()
        {
            try
            {
                pingResposta = gerenciadorCliente.ExecutarPing(ping);
            }
            catch (PingSemRespostaException ex)
            {
                pingResposta = null;
            }
        }

        [Given(@"que informei (.*) como porta do servidor")]
        public void DadoQueInformeiUmValorComoPortaDoServidor(int portaServidor)
        {
            gerenciadorServidor = new GerenciadorPing(portaServidor);
            gerenciadorServidor.PortaRecebimento.Should().Be(portaServidor);
        }

        [When(@"eu clicar em ""Iniciar Servidor""")]
        public void QuandoEuClicarEmIniciarServidor()
        {
            gerenciadorServidor.IniciarServidor();
        }

        [Then(@"o servidor de Ping deverá estar ativo")]
        public void EntaoOServidorDePingDeveraEstarAtivo()
        {
            gerenciadorServidor.ServidorAtivo.Should().Be(true);
        }

        [Given(@"que o servidor de Ping está ativo")]
        public void DadoQueOServidorDePingEstaAtivo()
        {
            if (!gerenciadorServidor.ServidorAtivo)
                gerenciadorServidor.IniciarServidor();
                
            gerenciadorServidor.ServidorAtivo.Should().Be(true);
        }

        [Then(@"o servidor Ping deverá estar desativado")]
        public void EntaoOServidorPingDeveraEstarDesativado()
        {
            gerenciadorServidor.ServidorAtivo.Should().Be(false);
        }

        [When(@"eu clicar em ""Parar Servidor""")]
        public void QuandoEuClicarEmPararServidor()
        {
            gerenciadorServidor.PararEntradaPacotes();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SharpTestsEx;
using ProjetoPingUDP.Model;

namespace ProjetoPingUDP.Specs
{
    [Binding]
    public class PingUdpStep
    {
        PingUdp ping = new PingUdp();
        ResultadoPing resultado = null;
        ServidorPingUdp servidor = new ServidorPingUdp();

        [Given(@"que informei (.*) como IP do destino")]
        public void DadoQueInformeiUmValorComoIPDoDestino(string ipDestino)
        {
            ping.IPDestino = ipDestino;

            ping.IPDestino.Should().Be(ipDestino);
        }

        [Given(@"que informei (.*) como porta do destino")]
        public void DadoQueInformeiUmValorComoPortaDoDestino(int portaDestino)
        {
            ping.PortaDestino = portaDestino;

            ping.PortaDestino.Should().Be(portaDestino);
        }

        [Given(@"que informei (.*) como número de pacotes")]
        public void DadoQueInformei4ComoNumeroDePacotes(int numeroPacotes)
        {
            ping.NumeroPacotes = numeroPacotes;

            ping.NumeroPacotes.Should().Be(numeroPacotes);
        }

        [Then(@"deverei receber o resultado do Ping com as estatísticas da rede")]
        public void EntaoDevereiReceberOResultadoDoPingComAsEstatisticasDaRede()
        {
            resultado.Should().Not.Be.Null();
        }

        [Then(@"o pacote Ping deverá ser executado")]
        public void EntaoOPacotePingDeveraSerExecutado()
        {
            ping.Executado.Should().Be(true);
        }

        [When(@"eu clicar em ""Executar Ping""")]
        public void QuandoEuClicarEmExecutarPing()
        {
            resultado = ping.Executar();
        }

        [Then(@"o resultado deve conter pelo menos (.*) pacote\(s\) perdido\(s\)")]
        public void EntaoOResultadoDeveConterPeloMenosUmValorDePacotesPerdidos(int numeroPacotesPerdidos)
        {
            resultado.PacotesPerdidos.Should().Be.GreaterThanOrEqualTo(numeroPacotesPerdidos);
        }

        [Then(@"o resultado deve conter pelo menos (.*) pacote\(s\) respondido\(s\)")]
        public void EntaoOResultadoDeveConterPeloMenosUmValorDePacotesRespondidos(int numeroPacotesRespondidos)
        {
            resultado.PacotesRecebidos.Should().Be.GreaterThanOrEqualTo(numeroPacotesRespondidos);
        }

        [Given(@"que informei (.*) como porta do servidor")]
        public void DadoQueInformeiUmValorComoPortaDoServidor(int portaServidor)
        {
            servidor.Porta = portaServidor;

            servidor.Porta.Should().Be(portaServidor);
        }

        [Then(@"o servidor de Ping deverá estar ativo")]
        public void EntaoOServidorDePingDeveraEstarAtivo()
        {
            servidor.Ativo.Should().Be(true);
        }

        [When(@"eu clicar em ""Iniciar Servidor""")]
        public void QuandoEuClicarEmIniciarServidor()
        {
            servidor.Iniciar();
        }

        [Given(@"que o servidor de Ping está ativo")]
        public void DadoQueOServidorDePingEstaAtivo()
        {
            servidor.Iniciar();

            servidor.Ativo.Should().Be(true);
        }

        [Then(@"o servidor Ping deverá estar desativado")]
        public void EntaoOServidorPingDeveraEstarDesativado()
        {
            servidor.Ativo.Should().Be(false);
        }

        [When(@"eu clicar em ""Parar Servidor""")]
        public void QuandoEuClicarEmPararServidor()
        {
            servidor.Parar();
        }
    }
}

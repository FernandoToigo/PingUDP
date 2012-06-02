using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoPingUDP.Model;
using SharpTestsEx;

namespace ProjetoPingUDP.Tests
{
    [TestClass]
    public class PingUDPTests
    {
        [TestMethod]
        public void Informando127Ponto0Ponto0Ponto1ComoIPDestino()
        {
            var ping = new PingUdp();
            var expected = "127.0.0.1";

            ping.IPDestino = expected;

            ping.IPDestino.Should().Be(expected);
        }

        [TestMethod]
        public void Informando8523ComoPortaDestino()
        {
            var ping = new PingUdp();
            var expected = 8523;

            ping.PortaDestino = expected;

            ping.PortaDestino.Should().Be(expected);
        }

        [TestMethod]
        public void Informando4ComoNumeroDePacotes()
        {
            var ping = new PingUdp();
            var expected = 4;

            ping.NumeroPacotes = expected;

            ping.NumeroPacotes.Should().Be(expected);
        }

        [TestMethod]
        public void ExecutandoPingComIPDestino127Ponto0Ponto0Ponto1EComPortaDestino8523DeveObterUmResultadoDePing()
        {
            PingUdp ping = new PingUdp();
            ping.IPDestino = "127.0.0.1";
            ping.PortaDestino = 8523;

            ResultadoPing resultado = ping.Executar();

            resultado.Should().Not.Be.Null();
        }
    }
}

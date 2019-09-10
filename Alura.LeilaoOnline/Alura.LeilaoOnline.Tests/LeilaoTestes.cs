﻿using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    // A classe de testes deve sempre ser pública
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComTresClientes()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Funano", leilao);
            var maria = new Interessada("Maria", leilao);
            var beltrano = new Interessada("Beltrano", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(beltrano, 1400);



            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 1400;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(beltrano, leilao.Ganhador.Cliente);

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComLancesOrdenadosPorValor()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Funano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(fulano, 1000);


            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }


        // Anotação necessária para que o framework reconheça o método como um teste de unidade.
        [Fact]
        public void LeilaoComVariosLances()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Funano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);


            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLance()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Funano", leilao);

            leilao.RecebeLance(fulano, 800);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}

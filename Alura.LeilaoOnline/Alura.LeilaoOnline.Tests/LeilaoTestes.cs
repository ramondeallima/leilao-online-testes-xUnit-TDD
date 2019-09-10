using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    // A classe de testes deve sempre ser pública
    public class LeilaoTestes
    {

        // Anotação necessária para que o framework reconheça o método como um teste de unidade.
        [Theory]
        [InlineData(1000, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void LeilaoComVariosLances(
            double valorEsperado, 
            double[] ofertas)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Funano", leilao);
            var maria = new Interessada("Maria", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoSemLances()
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert 
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}

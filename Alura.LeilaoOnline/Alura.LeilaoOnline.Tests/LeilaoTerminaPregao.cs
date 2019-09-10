using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    // Boas práticas para nomenclatura de classes e métodos de testes

    // O nome da classe de teste, deve ser o nome da classe e o 
    // método sendo testado.
    public class LeilaoTerminaPregao
    {

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]

        // O nome do método deve ser o comportamento esperado
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(
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
        // O nome do método deve ser o comportamento esperado
        public void RetornaZeroDadoLeilaoSemLances()
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

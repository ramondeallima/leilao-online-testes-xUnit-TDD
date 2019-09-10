using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        // Facts: São sempre utilizadas quando o teste não depende de valores de entrada

        // Theory: É utilizado quando são testadas várias condições de entrada para o mesmo teste

        [Theory]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300})]
        [InlineData(2, new double[] { 800, 900})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            //Arranje - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            leilao.TerminaPregao();

            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert 
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtida);
        }
    }
}

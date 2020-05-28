using CafeteiraEletrica.Teste.Stubs;
using CoffeeMaker;
using CoffeeMakerApi;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CafeteiraEletrica.Teste
{
    [Binding]
    public class CicloDeProducaoDeCafeStep
    {
        CoffeeMakerApiStub coffeeMakerApi;
        CoffeeMake coffeeMake;

        [Given(@"uma cafeteira elétrica em perfeito funcionamento")]
        public void GivenUmaCafeteiraEletricaEmPerfeitoFuncionamento()
        {
            coffeeMakerApi = new CoffeeMakerApiStub();
            coffeeMake = new CoffeeMake();
        }

        [Given(@"abastecido com água o respectivo receptáculo")]
        public void GivenAbastecidoComAguaORespectivoReceptaculo()
        {
            coffeeMakerApi.SetBoilerStatus(BoilerStatus.NOT_EMPTY);
            Thread.Sleep(2000);
        }

        [Given(@"uma jarra vazia acoplada para coleta do café")]
        public void GivenUmaJarraVaziaAcopladaParaColetaDoCafe()
        {
            coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
            Thread.Sleep(2000);
        }

        [Given(@"o café pronto para o consumo")]
        public void GivenOCafeProntoParaOConsumo()
        {
            GivenUmaCafeteiraEletricaEmPerfeitoFuncionamento();
            GivenAbastecidoComAguaORespectivoReceptaculo();
            GivenUmaJarraVaziaAcopladaParaColetaDoCafe();
            WhenPressionadaAOpcaoPreparar();
            ThenOCafeEstaProntoEMantidoAquecido();
            Thread.Sleep(2000);
        }

        [When(@"pressionada a opção preparar")]
        public void WhenPressionadaAOpcaoPreparar()
        {
            coffeeMakerApi.SetBrewButtonStatus(BrewButtonStatus.PUSHED);
            //coffeeMake.Main(coffeeMakerApi);
            Task.Run(() => coffeeMake.Main(coffeeMakerApi));
            Thread.Sleep(4000);
        }

        [When(@"identificado que foi servido por completo")]
        public void WhenIdentificadoQueFoiServidoPorCompleto()
        {
            coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
            coffeeMakerApi.SetBrewButtonStatus(BrewButtonStatus.NOT_PUSHED);
            Thread.Sleep(2000);
        }

        [Then(@"o café está pronto e mantido aquecido")]
        public void ThenOCafeEstaProntoEMantidoAquecido()
        {
            Assert.That(coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.ON));
            Assert.That(coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.POT_NOT_EMPTY));
            Assert.That(coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.EMPTY));
            Assert.That(coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.OFF));
            Assert.That(coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.CLOSED));
            Assert.That(coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.ON));
        }

        [Then(@"o ciclo de preparação do café e finalizado")]
        public void ThenOClicloDeConfeccaoDoCafeEFinalizado()
        {
            Assert.That(coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.POT_EMPTY));
        }
    }
}
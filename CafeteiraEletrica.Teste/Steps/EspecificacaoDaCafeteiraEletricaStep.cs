using CafeteiraEletrica.Teste.Stubs;
using CoffeeMakerApi;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CafeteiraEletrica.Teste.Steps
{
    [Binding]
    public class EspecificacaoDaCafeteiraEletricaStep
    {
        private M4FonteDeAguaQuente _fonteDeAguaQuente;
        private CoffeeMakerApiStub _coffeeMakerApiStub = new CoffeeMakerApiStub();
        private M4RecipienteDeContencao _recipienteDeContencao;
        private M4InterfaceDoUsuario _interfaceDoUsuario;


        [Given(@"uma fonte de água quente")]
        public void GivenUmaFonteDeAguaQuente()
        {
            _fonteDeAguaQuente = new M4FonteDeAguaQuente(_coffeeMakerApiStub);
        }

        [Given(@"que a fonte não contém água")]
        public void GivenQueAFonteNaoContemAgua()
        {
            _coffeeMakerApiStub.SetBoilerStatus(BoilerStatus.EMPTY);
        }

        [Given(@"um recipiente de contenção")]
        public void GivenUmRecipienteDeContencao()
        {
            _recipienteDeContencao = new M4RecipienteDeContencao(_coffeeMakerApiStub);
        }

        [Given(@"que o recipiente não esteja acoplado")]
        public void GivenQueORecipienteNaoEstejaAcoplado()
        {
            _coffeeMakerApiStub.SetWarmerPlateStatus(WarmerPlateStatus.WARMER_EMPTY);
        }

        [Given(@"um interface de usuario")]
        public void GivenUmInterfaceDeUsuario()
        {
            _interfaceDoUsuario = new M4InterfaceDoUsuario(_coffeeMakerApiStub);            
        }

        [Given(@"que o preparo do café foi iniciado")]
        public void GivenQueOPreparoDoCafeFoiIniciado()
        {
            throw new PendingStepException();
        }

        [Given(@"o preparo do café e interrompido")]
        public void GivenOPreparoDoCafeEInterrompido()
        {
            throw new PendingStepException();
        }

        [Given(@"o preparo do café e iniciado")]
        public void GivenOPreparoDoCafeEIniciado()
        {
            throw new PendingStepException();
        }

        [Given(@"o café pronto para consumo")]
        public void GivenOCafeProntoParaConsumo()
        {
            throw new PendingStepException();
        }

        [Given(@"pressionado o botão de inicio")]
        public void GivenPressionadoOBotaoDeInicio()
        {
            _coffeeMakerApiStub.SetBrewButtonStatus(BrewButtonStatus.PUSHED);
        }

        [When(@"iniciado o preparo de café")]
        public void WhenIniciadoOPreparoDeCafe()
        {
            _interfaceDoUsuario.Inicio(_fonteDeAguaQuente, _recipienteDeContencao);
            _interfaceDoUsuario.Preparando();
        }

        [When(@"o recipiente de conteção e extraido")]
        public void WhenORecipienteDeContecaoEExtraido()
        {
            throw new PendingStepException();
        }

        [When(@"o recipiente de conteção e devolvido")]
        public void WhenORecipienteDeContecaoEDevolvido()
        {
            throw new PendingStepException();
        }

        [When(@"comcluido o preparo do café")]
        public void WhenComcluidoOPreparoDoCafe()
        {
            throw new PendingStepException();
        }

        [When(@"identificado o consumido completo")]
        public void WhenIdentificadoOConsumidoCompleto()
        {
            throw new PendingStepException();
        }
        
        [When(@"identificado que ainda não foi consumido por completo")]
        public void WhenIdentificadoQueAindaNaoFoiConsumidoPorCompleto()
        {
            throw new PendingStepException();
        }

        [Then(@"o preparo do café não e iniciado")]
        public void ThenOPreparoDoCafeNaoEIniciado()
        {
            Assert.That(_coffeeMakerApiStub.GetBoilerStatus(), Is.EqualTo(BoilerStatus.EMPTY));
            Assert.That(_coffeeMakerApiStub.GetBoilerState(), Is.EqualTo(BoilerState.OFF));
            Assert.That(_coffeeMakerApiStub.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.WARMER_EMPTY));
            Assert.That(_coffeeMakerApiStub.GetWarmerState, Is.EqualTo(WarmerState.OFF));
            Assert.That(_coffeeMakerApiStub.GetReliefValveState, Is.EqualTo(ReliefValveState.OPEN));
            Assert.That(_coffeeMakerApiStub.GetIndicatorState, Is.EqualTo(IndicatorState.OFF));
            Assert.That(_coffeeMakerApiStub.GetBrewButtonStatus, Is.EqualTo(BrewButtonStatus.PUSHED));
        }

        [Then(@"o preparo do café e iniciado")]
        public void ThenOPreparoDoCafeEIniciado()
        {
            throw new PendingStepException();
        }

        [Then(@"o preparo do café e interrompido")]
        public void ThenOPreparoDoCafeEInterrompido()
        {
            throw new PendingStepException();
        }

        [Then(@"o preparo do café e retomado")]
        public void ThenOPreparoDoCafeERetomado()
        {
            throw new PendingStepException();
        }

        [Then(@"mantido aquecido até ser consumo por completo")]
        public void ThenMantidoAquecidoAteSerConsumoPorCompleto()
        {
            throw new PendingStepException();
        }

        [Then(@"o café está pronto para o consumo")]
        public void ThenOCafeEstaProntoParaOConsumo()
        {
            throw new PendingStepException();
        }

        [Then(@"o ciclo de preparo e finalizado")]
        public void ThenOCicloDePreparoEFinalizado()
        {
            throw new PendingStepException();
        }
    }
}

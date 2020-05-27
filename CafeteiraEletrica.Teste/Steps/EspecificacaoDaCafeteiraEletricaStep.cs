using CafeteiraEletrica.Teste.Stubs;
using CoffeeMakerApi;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CafeteiraEletrica.Teste.Steps
{
    [Binding]
    public class EspecificacaoDaCafeteiraEletricaStep
    {
        private CoffeeMakerApiStub _coffeeMakerApi;
        private M4FonteDeAguaQuente _fonteDeAguaQuente;
        private M4RecipienteDeContencao _recipienteDeContencao;
        private M4InterfaceDoUsuario _interfaceDoUsuario;

        [BeforeScenario]
        public void IniciarApiStub()
        {
            _coffeeMakerApi = new CoffeeMakerApiStub();
        }

        public void Poll()
        {
            _fonteDeAguaQuente.Poll();
            _recipienteDeContencao.Poll();
            _interfaceDoUsuario.Poll();
        }

        #region GIVEN
        [Given(@"uma fonte de água quente")]
        public void GivenUmaFonteDeAguaQuente()
        {
            _fonteDeAguaQuente =  new M4FonteDeAguaQuente(_coffeeMakerApi);
        }

        [Given(@"que a fonte não contém água")]
        public void GivenQueAFonteNaoContemAgua()
        {
            _coffeeMakerApi.SetBoilerStatus(BoilerStatus.EMPTY);
        }

        [Given(@"um recipiente de contenção")]
        public void GivenUmRecipienteDeContencao()
        {
            _recipienteDeContencao = new M4RecipienteDeContencao(_coffeeMakerApi);
        }

        [Given(@"que o recipiente não esteja acoplado")]
        public void GivenQueORecipienteNaoEstejaAcoplado()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.WARMER_EMPTY);
        }

        [Given(@"uma interface de usuário")]
        public void GivenUmInterfaceDeUsuario()
        {
            _interfaceDoUsuario = new M4InterfaceDoUsuario(_coffeeMakerApi);

            _fonteDeAguaQuente.Iniciar(_interfaceDoUsuario, _recipienteDeContencao);
            _recipienteDeContencao.Iniciar(_interfaceDoUsuario, _fonteDeAguaQuente);
            _interfaceDoUsuario.Iniciar(_fonteDeAguaQuente, _recipienteDeContencao);
        }

        [Given(@"que o preparo do café foi iniciado")]
        public void GivenQueOPreparoDoCafeFoiIniciado()
        {
            GivenUmaFonteDeAguaQuente();
            GivenQueAFonteContemAgua();

            GivenUmRecipienteDeContencao();
            GivenQueORecipienteEstejaAcoplado();

            GivenUmInterfaceDeUsuario();
            GivePressionadoOBotaoDeInicio();

            GivenIniciadoOPreparoDoCafe();

            ThenOPreparoDoCafeEIniciado();
        }

        [Given(@"pressionado o botão de início")]
        public void GivePressionadoOBotaoDeInicio()
        {
            _coffeeMakerApi.SetBrewButtonStatus(BrewButtonStatus.PUSHED);
        }

        [Given(@"o preparo do café é interrompido")]
        public void GivenOPreparoDoCafeEInterrompido()
        {
            GivenQueOPreparoDoCafeFoiIniciado();
            WhenORecipienteDeContecaoEExtraido();
            ThenOPreparoDoCafeEInterrompido();
        }

        [Given(@"o café pronto para consumo")]
        public void GivenOCafeProntoParaConsumo()
        {
            GivenQueOPreparoDoCafeFoiIniciado();
            WhenConcluidoOPreparoDoCafe();
            ThenOCafeEstaProntoParaOConsumo();
            ThenMantidoAquecidoAteSerConsumidoPorCompleto();
        }

        [Given(@"que a fonte contém água")]
        public void GivenQueAFonteContemAgua()
        {
            _coffeeMakerApi.SetBoilerStatus(BoilerStatus.NOT_EMPTY);
        }

        [Given(@"que o recipiente esteja acoplado")]
        public void GivenQueORecipienteEstejaAcoplado()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
        }

        #endregion

        #region WHEN
        [When(@"iniciado o preparo do café")]
        public void GivenIniciadoOPreparoDoCafe()
        {
            _interfaceDoUsuario.Preparar();
            Poll();
        }

        [When(@"o recipiente de contenção é extraído")]
        public void WhenORecipienteDeContecaoEExtraido()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.WARMER_EMPTY);
            Poll();
        }

        [When(@"o recipiente de contenção é devolvido")]
        public void WhenORecipienteDeContecaoEDevolvido()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
            Poll();
        }

        [When(@"concluído o preparo do café")]
        public void WhenConcluidoOPreparoDoCafe()
        {
            _coffeeMakerApi.SetBoilerStatus(BoilerStatus.EMPTY);
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_NOT_EMPTY);
            Poll();
        }

        [When(@"identificado o consumo completo")]
        public void WhenIdentificadoOConsumidoCompleto()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_EMPTY);
            Poll();
        }
        
        [When(@"identificado que ainda não foi consumido por completo")]
        public void WhenIdentificadoQueAindaNaoFoiConsumidoPorCompleto()
        {
            _coffeeMakerApi.SetWarmerPlateStatus(WarmerPlateStatus.POT_NOT_EMPTY);
            Poll();
        }
        #endregion

        #region THEN
        [Then(@"o preparo do café não é iniciado")]
        public void ThenOPreparoDoCafeNaoEIniciado()
        {
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.OFF));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.OFF));
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.OPEN));
            Assert.That(_coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.OFF));
        }

        [Then(@"o preparo do café é iniciado")]
        public void ThenOPreparoDoCafeEIniciado()
        {
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.ON));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.POT_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.ON));
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.CLOSED));
        }

        [Then(@"o preparo do café é interrompido")]
        public void ThenOPreparoDoCafeEInterrompido()
        { 
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.OFF));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.WARMER_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.OFF));
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.OPEN));
        }

        [Then(@"o preparo do café é retomado")]
        public void ThenOPreparoDoCafeERetomado()
        {
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.ON));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), 
                Is.EqualTo(WarmerPlateStatus.POT_EMPTY).Or.EqualTo(WarmerPlateStatus.POT_NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.ON));
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.CLOSED));
        }

        [Then(@"mantido aquecido até ser consumido por completo")]
        public void ThenMantidoAquecidoAteSerConsumidoPorCompleto()
        {
            Assert.That(_coffeeMakerApi.GetBoilerStatus(), Is.EqualTo(BoilerStatus.EMPTY));
            Assert.That(_coffeeMakerApi.GetReliefValveState(), Is.EqualTo(ReliefValveState.OPEN));
            Assert.That(_coffeeMakerApi.GetBoilerState(), Is.EqualTo(BoilerState.OFF));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.POT_NOT_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.ON));
        }

        [Then(@"o café está pronto para o consumo")]
        public void ThenOCafeEstaProntoParaOConsumo()
        {
            Assert.That(_coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.ON));
        }

        [Then(@"o ciclo de preparo é finalizado")]
        public void ThenOCicloDePreparoEFinalizado()
        {
            Assert.That(_coffeeMakerApi.GetIndicatorState(), Is.EqualTo(IndicatorState.OFF));
            Assert.That(_coffeeMakerApi.GetWarmerPlateStatus(), Is.EqualTo(WarmerPlateStatus.POT_EMPTY));
            Assert.That(_coffeeMakerApi.GetWarmerState(), Is.EqualTo(WarmerState.OFF));
        }
        #endregion
    }
}

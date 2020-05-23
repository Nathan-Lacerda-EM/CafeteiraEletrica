using System;
using CafeteiraEletrica.Teste.Stubs;
using CoffeeMakerApi;
using TechTalk.SpecFlow;

namespace CafeteiraEletrica.Teste.Steps
{
    [Binding]
    public class EspecificacaoDaCafeteiraEletricaStep
    {
        private CoffeeMakerApiStub _coffeeMakerApi = new CoffeeMakerApiStub();
        private M4FonteDeAguaQuente _fonteDeAguaQuente;
        private M4RecipienteDeContencao _recipienteDeContencao;

        [Given(@"uma fonte de água quente")]
        public void GivenUmaFonteDeAguaQuente()
        {
            _fonteDeAguaQuente = new M4FonteDeAguaQuente();
        }

        [Given(@"que a fonte não contém água")]
        public void GivenQueAFonteNaoContemAgua()
        {
            _coffeeMakerApi.SetBoilerStatus(BoilerStatus.EMPTY);
        }

        [Given(@"um recipiente de contenção")]
        public void GivenUmRecipienteDeContencao()
        {
            throw new PendingStepException();
        }

        [Given(@"que o recipiente não esteja acoplado")]
        public void GivenQueORecipienteNaoEstejaAcoplado()
        {
            throw new PendingStepException();
        }

        [Given(@"um interface de usuario")]
        public void GivenUmInterfaceDeUsuario()
        {
            throw new PendingStepException();
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

        [When(@"precionado o botão de inicio na interface de usuario")]
        public void WhenPrecionadoOBotaoDeInicioNaInterfaceDeUsuario()
        {
            throw new PendingStepException();
        }

        [When(@"o usuario precionar o botão de inicio")]
        public void WhenOUsuarioPrecionarOBotaoDeInicio()
        {
            throw new PendingStepException();
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
            throw new PendingStepException();
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

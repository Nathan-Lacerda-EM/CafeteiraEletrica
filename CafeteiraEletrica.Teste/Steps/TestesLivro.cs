using CoffeeMakerApi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica.Teste.Steps
{
    internal class CoffeeMakerStub2 : ICoffeeMakerApi
    {
        public bool buttonPressed;
        public bool lightOn;
        public bool boilerOn;
        public bool valveClosed;
        public bool plateOn;
        public bool boilerEmpty;
        public bool potPresent;
        public bool potNotEmpty;
        public CoffeeMakerStub2()
        {
            buttonPressed = false;
            lightOn = false;
            boilerOn = false;
            valveClosed = true;
            plateOn = false;
            boilerEmpty = true;
            potPresent = true;
            potNotEmpty = false;
        }
        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            if (!potPresent)
                return WarmerPlateStatus.WARMER_EMPTY;
            else if (potNotEmpty)
                return WarmerPlateStatus.POT_NOT_EMPTY;
            else
                return WarmerPlateStatus.POT_EMPTY;
        }
        public BoilerStatus GetBoilerStatus()
        {
            return boilerEmpty ?
            BoilerStatus.EMPTY : BoilerStatus.NOT_EMPTY;
        }
        public BrewButtonStatus GetBrewButtonStatus()
        {
            if (buttonPressed)
            {
                buttonPressed = false;
                return BrewButtonStatus.PUSHED;
            }
            else
            {
                return BrewButtonStatus.NOT_PUSHED;
            }
        }
        public void SetBoilerState(BoilerState boilerState)
        {
            boilerOn = boilerState == BoilerState.ON;
        }
        public void SetWarmerState(WarmerState warmerState)
        {
            plateOn = warmerState == WarmerState.ON;
        }
        public void
        SetIndicatorState(IndicatorState indicatorState)
        {
            lightOn = indicatorState == IndicatorState.ON;
        }
        public void
        SetReliefValveState(ReliefValveState reliefValveState)
        {
            valveClosed = reliefValveState == ReliefValveState.CLOSED;
        }
    }

    [TestFixture]
    public class TestesLivro
    {
        private M4InterfaceDoUsuario ui;
        private M4FonteDeAguaQuente hws;
        private M4RecipienteDeContencao cv;
        private CoffeeMakerStub2 api;
        [SetUp]
        public void SetUp()
        {
            api = new CoffeeMakerStub2();
            ui = new M4InterfaceDoUsuario(api);
            hws = new M4FonteDeAguaQuente(api);
            cv = new M4RecipienteDeContencao(api);
            ui.Iniciar(hws, cv);
            hws.Iniciar(ui, cv);
            cv.Iniciar(ui, hws);
        }
        private void Poll()
        {
            ui.Preparar();
            hws.Preparar();
            cv.Preparar();
        }
        [Test]
        public void InitialConditions()
        {
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void StartNoPot()
        {
            Poll();
            api.buttonPressed = true;
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void StartNoWater()
        {
            Poll();
            api.buttonPressed = true;
            api.boilerEmpty = true;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }

        [Test]
        public void GoodStart()
        {
            NormalStart();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        private void NormalStart()
        {
            Poll();
            api.boilerEmpty = false;
            api.buttonPressed = true;
            Poll();
        }
        [Test]
        public void StartedPotNotEmpty()
        {
            NormalStart();
            api.potNotEmpty = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void PotRemovedAndReplacedWhileEmpty()
        {
            NormalStart();
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsFalse(api.valveClosed);
            api.potPresent = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedEmpty()
        {
            NormalFill();
            api.potPresent = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsFalse(api.valveClosed);
            api.potPresent = true;
            api.potNotEmpty = false;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        private void NormalFill()
        {
            NormalStart();
            api.potNotEmpty = true;
            Poll();
        }
        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedNotEmpty()
        {
            NormalFill();
            api.potPresent = false;
            Poll();
            api.potPresent = true;
            Poll();
            Assert.IsTrue(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void BoilerEmptyPotNotEmpty()
        {
            NormalBrew();
            Assert.IsFalse(api.boilerOn);
            Assert.IsTrue(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        private void NormalBrew()
        {
            NormalFill();
            api.boilerEmpty = true;
            Poll();
        }
        [Test]
        public void BoilerEmptiesWhilePotRemoved()
        {
            NormalFill();
            api.potPresent = false;
            Poll();
            api.boilerEmpty = true;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsTrue(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
            api.potPresent = true;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsTrue(api.lightOn);
            Assert.IsTrue(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
        [Test]
        public void EmptyPotReturnedAfter()
        {
            NormalBrew();
            api.potNotEmpty = false;
            Poll();
            Assert.IsFalse(api.boilerOn);
            Assert.IsFalse(api.lightOn);
            Assert.IsFalse(api.plateOn);
            Assert.IsTrue(api.valveClosed);
        }
    }
}
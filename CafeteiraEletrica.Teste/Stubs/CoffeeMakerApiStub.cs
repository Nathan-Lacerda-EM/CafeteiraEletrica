using CoffeeMakerApi;

namespace CafeteiraEletrica.Teste.Stubs
{
    public sealed class CoffeeMakerApiStub : ICoffeeMakerApi
    {
        public BrewButtonStatus BrewButtonStatus { private get; set; } = BrewButtonStatus.NOT_PUSHED;
        public BoilerStatus BoilerStatus { private get; set; } = BoilerStatus.EMPTY;
        public WarmerPlateStatus WarmerPlateStatus { private get; set; } = WarmerPlateStatus.WARMER_EMPTY;
        public ReliefValveState ReliefValveState { private get; set; } = ReliefValveState.OPEN;
        public IndicatorState IndicatorState { private get; set; } = IndicatorState.OFF;
        public WarmerState WarmerState { private get; set; } = WarmerState.OFF;
        public BoilerState BoilerState { private get; set; } = BoilerState.OFF;

        public BoilerStatus GetBoilerStatus()
        {
            return BoilerStatus;
        }

        private bool buttonPressed;

        public BrewButtonStatus GetBrewButtonStatus()
        {
            if (!buttonPressed)
            {
                buttonPressed = true;
                return BrewButtonStatus.PUSHED;
            }
            else
            {
                return BrewButtonStatus.NOT_PUSHED;
            }
        }

        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            return WarmerPlateStatus;
        }
        
        public void SetBoilerState(BoilerState boilerState)
        {
            BoilerState = boilerState;
        }

        public IndicatorState GetIndicatorState()
        {
            return IndicatorState;
        }

        public void SetIndicatorState(IndicatorState indicatorState)
        {
            IndicatorState = indicatorState;
        }

        public void SetReliefValveState(ReliefValveState reliefValveState)
        {
            ReliefValveState = reliefValveState;
        }

        public void SetWarmerState(WarmerState warmerState)
        {
            WarmerState = warmerState;
        }

        protected internal void SetBoilerStatus(BoilerStatus boilerStatus)
        {
            BoilerStatus = boilerStatus;
        }

        protected internal void SetBrewButtonStatus(BrewButtonStatus brewButtonStatus)
        {
            BrewButtonStatus = brewButtonStatus;
        }

        protected internal void SetWarmerPlateStatus(WarmerPlateStatus warmerPlateStatus)
        {
            WarmerPlateStatus = warmerPlateStatus;
        }

        protected internal BoilerState GetBoilerState()
        {
            return BoilerState;
        }

        protected internal ReliefValveState GetReliefValveState()
        {
            return ReliefValveState;
        }

        protected internal WarmerState GetWarmerState()
        {
            return WarmerState;
        }
    }
}

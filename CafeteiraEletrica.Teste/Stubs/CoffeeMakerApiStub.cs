using CoffeeMakerApi;

namespace CafeteiraEletrica.Teste.Stubs
{
    public class CoffeeMakerApiStub : ICoffeeMakerApi
    {
        public BrewButtonStatus BrewButtonStatus { private get; set; } = BrewButtonStatus.NOT_PUSHED;
        public BoilerStatus BoilerStatus { private get; set; } = BoilerStatus.EMPTY;
        public WarmerPlateStatus WarmerPlateStatus { private get; set; } = WarmerPlateStatus.POT_EMPTY;
        public ReliefValveState ReliefValveState { private get; set; } = ReliefValveState.OPEN;
        public IndicatorState IndicatorState { private get; set; } = IndicatorState.OFF;
        public WarmerState WarmerState { private get; set; } = WarmerState.OFF;
        public BoilerState BoilerState { private get; set; } = BoilerState.OFF;

        public BoilerStatus GetBoilerStatus()
        {
            return BoilerStatus;
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            return BrewButtonStatus;
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

        internal void SetBoilerStatus(BoilerStatus boilerStatus)
        {
            BoilerStatus = boilerStatus;
        }

        internal void SetBrewButtonStatus(BrewButtonStatus brewButtonStatus)
        {
            BrewButtonStatus = brewButtonStatus;
        }

        internal void SetWarmerPlateStatus(WarmerPlateStatus warmerPlateStatus)
        {
            WarmerPlateStatus = warmerPlateStatus;
        }

        internal BoilerState GetBoilerState()
        {
            return BoilerState;
        }

        internal ReliefValveState GetReliefValveState()
        {
            return ReliefValveState;
        }

        internal WarmerState GetWarmerState()
        {
            return WarmerState;
        }
    }
}

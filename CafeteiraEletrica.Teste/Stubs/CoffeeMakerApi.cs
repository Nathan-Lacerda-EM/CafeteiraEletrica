using CoffeeMakerApi;

namespace CafeteiraEletrica.Teste.Stubs
{
    public class CoffeeMakerApi : ICoffeeMakerApi
    {
        private BrewButtonStatus _brewButtonStatus = BrewButtonStatus.NOT_PUSHED;
        private BoilerStatus _boilerStatus = BoilerStatus.EMPTY;
        private WarmerPlateStatus _warmerPlateStatus = WarmerPlateStatus.POT_EMPTY;
        private ReliefValveState _reliefValveState = ReliefValveState.CLOSED;
        private IndicatorState _indicatorState = IndicatorState.OFF;
        private WarmerState _warmerState = WarmerState.OFF;
        private BoilerState _boilerState = BoilerState.OFF;

        public BoilerStatus GetBoilerStatus()
        {
            return _boilerStatus;
        }

        internal void SetBoilerStatus(BoilerStatus boilerStatus)
        {
            _boilerStatus = boilerStatus;
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            return _brewButtonStatus;
        }

        internal void SetBrewButtonStatus(BrewButtonStatus brewButtonStatus)
        {
            _brewButtonStatus = brewButtonStatus;
        }

        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            return _warmerPlateStatus;
        }

        internal void SetWarmerPlateStatus(WarmerPlateStatus warmerPlateStatus)
        {
            _warmerPlateStatus = warmerPlateStatus;
        }

        internal BoilerState GetBoilerState()
        {
            return _boilerState;
        }

        public void SetBoilerState(BoilerState boilerState)
        {
            _boilerState = boilerState;
        }

        public IndicatorState GetIndicatorState()
        {
            return _indicatorState;
        }

        public void SetIndicatorState(IndicatorState indicatorState)
        {
            _indicatorState = indicatorState;
        }

        public void SetReliefValveState(ReliefValveState reliefValveState)
        {
            _reliefValveState = reliefValveState;
        }

        internal ReliefValveState GetReliefValveState()
        {
            return _reliefValveState;
        }

        internal WarmerState GetWarmerState()
        {
            return _warmerState;
        }

        public void SetWarmerState(WarmerState warmerState)
        {
            _warmerState = warmerState;
        }
    }
}

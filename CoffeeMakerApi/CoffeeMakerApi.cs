using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMakerApi
{
    public class CoffeeMakerApi : ICoffeeMakerApi
    {
        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            throw new NotImplementedException();
        }

        public BoilerStatus GetBoilerStatus()
        {
            throw new NotImplementedException();
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            throw new NotImplementedException();
        }

        public void SetBoilerState(BoilerState boilerState)
        {
            throw new NotImplementedException();
        }

        public void SetWarmerState(WarmerState warmerState)
        {
            throw new NotImplementedException();
        }

        public void SetIndicatorState(IndicatorState indicatorState)
        {
            throw new NotImplementedException();
        }

        public void SetReliefValveState(ReliefValveState reliefValveState)
        {
            throw new NotImplementedException();
        }
    }
}

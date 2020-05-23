using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4InterfaceDoUsuario : InterfaceDoUsuario, IPrepararCafe
    {
        private ICoffeeMakerApi _api;

        public M4InterfaceDoUsuario(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public void Preparar()
        {
            if(_api.GetBrewButtonStatus() == BrewButtonStatus.PUSHED && 
                _api.GetBoilerStatus() == BoilerStatus.NOT_EMPTY && 
                !(_api.GetWarmerPlateStatus() == WarmerPlateStatus.WARMER_EMPTY))
            {
                Iniciar();
                _api.SetIndicatorState(IndicatorState.ON);
            } else
            {
                Parar();
                _api.SetIndicatorState(IndicatorState.OFF);
            }
        }
    }
}

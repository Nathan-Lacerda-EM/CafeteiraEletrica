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
            if(_api.GetBrewButtonStatus() == BrewButtonStatus.PUSHED)
                IniciarPreparo();
        }

        public override void Pronto()
        {
            _api.SetIndicatorState(IndicatorState.ON);
        }

        public override void FinalizarCiclo()
        {
            _api.SetIndicatorState(IndicatorState.OFF);
        }
    }
}

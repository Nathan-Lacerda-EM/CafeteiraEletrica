using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4InterfaceDoUsuario : InterfaceDoUsuario, IPollable
    {
        private ICoffeeMakerApi _api;

        public M4InterfaceDoUsuario(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public void Poll()
        {
            if(_api.GetBrewButtonStatus() == BrewButtonStatus.PUSHED)
                Preparar();
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

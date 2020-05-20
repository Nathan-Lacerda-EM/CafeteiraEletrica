using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    class M4InterfaceDeUsuario : InterfaceDoUsuario
    {
        private ICoffeeMakerApi _api;

        private protected override void ConcluaPreparo()
        {
            _api.SetIndicatorState(IndicatorState.ON);
        }

        protected internal override void Finaliza()
        {
            _api.SetIndicatorState(IndicatorState.OFF);
        }
    }
}

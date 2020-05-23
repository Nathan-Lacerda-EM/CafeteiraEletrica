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

        public void Preparando()
        {
            if (_api.GetBrewButtonStatus() == BrewButtonStatus.PUSHED)
            {
                Iniciar();
            }
        }

        public override void AlteraStatusIndicador()
        {
            _api.SetIndicatorState(IndicatorState.OFF);
        }

        public override void InterrompaExecucao()
        {
            _api.SetBoilerState(BoilerState.OFF);
            _api.SetWarmerState(WarmerState.OFF);
            _api.SetReliefValveState(ReliefValveState.OPEN);
        }

        public override void RetornaExecucao()
        {
            _api.SetBoilerState(BoilerState.ON);
            _api.SetWarmerState(WarmerState.ON);
            _api.SetReliefValveState(ReliefValveState.CLOSED);
        }
    }
}

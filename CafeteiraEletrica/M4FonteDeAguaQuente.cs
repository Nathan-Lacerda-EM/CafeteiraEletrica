using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    class M4FonteDeAguaQuente : FonteDeAguaQuente
    {
        private ICoffeeMakerApi _api;

        protected internal override bool EstaPronto => _api.GetBoilerStatus() == BoilerStatus.NOT_EMPTY;

        private protected override void ComecaPreparo()
        {
            _api.SetReliefValveState(ReliefValveState.CLOSED);
            _api.SetBoilerState(BoilerState.ON);
        }

        private protected override void SuspendaFluxoDeAgua()
        {
            _api.SetBoilerState(BoilerState.OFF);
            _api.SetReliefValveState(ReliefValveState.OPEN);
        }

        private protected override void RetomeFluxoDeAgua()
        {
            _api.SetBoilerState(BoilerState.ON);
            _api.SetReliefValveState(ReliefValveState.CLOSED);
        }

        private protected override void ConcluaPreparo()
        {
            _api.SetReliefValveState(ReliefValveState.OPEN);
            _api.SetBoilerState(BoilerState.OFF);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    class M4RecipienteDeContencao : RecipienteDeContencao
    {
        private ICoffeeMakerApi _api;
        protected internal override bool EstaPronto => _api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY;
        private protected override void ComecaPreparo()
        {
            _api.SetWarmerState(WarmerState.ON);
        }

        private protected override void SuspendaPreparo()
        {
            _api.SetWarmerState(WarmerState.OFF);
        }

        private protected override void RetomeFluxoDeAgua()
        {
            _api.SetWarmerState(WarmerState.ON);
        }

        protected internal override void ConcluaPreparo()
        {
            if (EstaPreparando)
            {
                ConcluirPreparo();
            }
        }

        private protected override void Finalize()
        {
            if (EstaConcluido) return;

            Finalizar();
            _api.SetWarmerState(WarmerState.OFF);
        }
    }
}

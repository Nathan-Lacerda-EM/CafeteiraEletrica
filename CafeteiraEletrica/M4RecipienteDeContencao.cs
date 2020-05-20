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
            if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY)
            {
                _api.SetWarmerState(WarmerState.ON);
            }
        }

        private protected override void SuspendaPreparo()
        {
            if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.WARMER_EMPTY)
            {
                _api.SetWarmerState(WarmerState.OFF);
                SuspenderFluxoDeAgua();
            }
        }

        private protected override void RetomePreparo()
        {
            if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                _api.SetWarmerState(WarmerState.ON);
                RetomarFluxoDeAgua();
            }
        }

        private protected override void Finalizar()
        {
            if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY)
            {
                _api.SetWarmerState(WarmerState.OFF);
                Finalize();
            }
        }
    }
}

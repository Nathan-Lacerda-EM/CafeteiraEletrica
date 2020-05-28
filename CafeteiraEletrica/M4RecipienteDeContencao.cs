using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CoffeeMakerApi;

namespace CafeteiraEletrica
{
    public class M4RecipienteDeContencao : RecipienteDeContencao, IPrepararCafe
    {
        private ICoffeeMakerApi _api;
        private WarmerPlateStatus ultimoWarmerPlateStatus;

        public M4RecipienteDeContencao(ICoffeeMakerApi api)
        {
            _api = api;
            ultimoWarmerPlateStatus = WarmerPlateStatus.POT_EMPTY;
        }

        protected internal override bool EstaPronto => _api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY;

        public override void Parar()
        {
            _api.SetWarmerState(WarmerState.OFF);
        }

        public override void Continuar()
        {
            _api.SetWarmerState(WarmerState.ON);
        }

        public void Preparar()
        {
            if (_api.GetWarmerPlateStatus() != ultimoWarmerPlateStatus)
            {
                if (EstaPreparando)
                    if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.WARMER_EMPTY)
                    {
                        Parar();
                        PararFonte();
                    }
                    else if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_NOT_EMPTY)
                    {
                        Continuar();
                        ContinuarFonte();
                    }
                    else
                    {
                        Parar();
                        ContinuarFonte();
                    }

                else if (!CicloCompleto)
                    if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_EMPTY)
                        Completar();
                    else if (_api.GetWarmerPlateStatus() == WarmerPlateStatus.POT_NOT_EMPTY)
                        Continuar();
                    else
                        Parar();
                ultimoWarmerPlateStatus = _api.GetWarmerPlateStatus();
            }
        }
    }
}

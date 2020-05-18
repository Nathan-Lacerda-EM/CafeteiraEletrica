using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    class RecipienteDeContencao
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private InterfaceDoUsuario _interfaceDoUsuario;

        void SuspenderFluxoDeAgua()
        {
            _fonteDeAguaQuente.SuspendaFluxoDeAgua();
        }

        void RetomarFluxoDeAgua()
        {
            _fonteDeAguaQuente.RetomeFluxoDeAgua();
        }

        void ConcluirPreparo()
        {
            _fonteDeAguaQuente.ConcluaPreparo();
            _interfaceDoUsuario.ConcluaPreparo();
        }

        void Finalizar()
        {
            _interfaceDoUsuario.Finaliza();
        }

        internal bool EstaPronto { get; set; }

        internal void Inicie()
        {
            throw new NotImplementedException();
        }

        internal void ConcluaPreparo()
        {
            throw new NotImplementedException();
        }
    }
}

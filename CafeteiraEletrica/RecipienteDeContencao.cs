using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    abstract class RecipienteDeContencao
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private InterfaceDoUsuario _interfaceDoUsuario;
        
        protected internal void IniciarPreparo()
        {
            ComecaPreparo();
        }

        protected internal void ConcluirPreparo()
        {
            _fonteDeAguaQuente.ConcluirPreparo();
            _interfaceDoUsuario.ConcluirPreparo();
        }

        private protected void SuspenderFluxoDeAgua()
        {
            _fonteDeAguaQuente.SuspenderFluxoDeAgua();
        }

        private protected void RetomarFluxoDeAgua()
        {
            _fonteDeAguaQuente.RetomarFluxoDeAgua();
        }

        private protected void Finalize()
        {
            _interfaceDoUsuario.Finaliza();
        }

        protected internal abstract bool EstaPronto { get; }
        private protected abstract void ComecaPreparo();
        private protected abstract void SuspendaPreparo();
        private protected abstract void RetomePreparo();
        private protected abstract void Finalizar();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    abstract class FonteDeAguaQuente
    {
        private RecipienteDeContencao _recipienteDeContencao;
        private InterfaceDoUsuario _interfaceDoUsuario;

        protected internal abstract bool EstaPronto { get; }

        protected internal void IniciarPreparo()
        {
            ComecaPreparo();
        }

        protected internal void SuspenderFluxoDeAgua()
        {
            SuspendaFluxoDeAgua();
        }

        protected internal void RetomarFluxoDeAgua()
        {
            RetomeFluxoDeAgua();
        }

 
        protected internal void ConcluirPreparo()
        {
            _recipienteDeContencao.ConcluirPreparo();
            _interfaceDoUsuario.ConcluirPreparo();
            ConcluaPreparo();
        }
        
        private protected abstract void ComecaPreparo();
        private protected abstract void SuspendaFluxoDeAgua();
        private protected abstract void RetomeFluxoDeAgua();
        private protected abstract void ConcluaPreparo();
    }
}

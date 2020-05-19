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
        protected bool EstaPreparando;

        private protected void ConcluirPreparo()
        {
            EstaPreparando = false;
            _recipienteDeContencao.ConcluaPreparo();
            _interfaceDoUsuario.ConcluaPreparo();
        }

        internal void Inicia()
        {
            EstaPreparando = true;
            ComecaPreparo();
        }

        protected internal abstract bool EstaPronto { get; }
        private protected abstract void ComecaPreparo();
        protected internal abstract void SuspendaFluxoDeAgua();
        protected internal abstract void RetomeFluxoDeAgua();
        protected internal abstract void ConcluaPreparo();
    }
}

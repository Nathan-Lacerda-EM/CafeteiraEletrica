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
        protected bool EstaPreparando;
        protected bool EstaConcluido;

        public RecipienteDeContencao()
        {
            EstaPreparando = false;
            EstaConcluido = true;
        }

        protected internal void Inicia()
        {
            EstaPreparando = true;
            EstaConcluido = false;
            ComecaPreparo();
        }

        void SuspenderFluxoDeAgua()
        {
            _fonteDeAguaQuente.SuspendaFluxoDeAgua();
            SuspendaPreparo();
        }

        void RetomarFluxoDeAgua()
        {
            _fonteDeAguaQuente.RetomeFluxoDeAgua();
            RetomeFluxoDeAgua();
        }

        private protected void ConcluirPreparo()
        {
            EstaPreparando = false;
            _fonteDeAguaQuente.ConcluaPreparo();
            _interfaceDoUsuario.ConcluaPreparo();
        }

        private protected void Finalizar()
        {
            EstaConcluido = true;
            _interfaceDoUsuario.Finaliza();
        }

        protected internal abstract bool EstaPronto { get; }
        private protected abstract void ComecaPreparo();
        private protected abstract void SuspendaPreparo();
        private protected abstract void RetomeFluxoDeAgua();
        protected internal abstract void ConcluaPreparo();
        private protected abstract void Finalize();
    }
}

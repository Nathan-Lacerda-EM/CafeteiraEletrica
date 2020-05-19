using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    abstract class InterfaceDoUsuario
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private RecipienteDeContencao _recipienteDeContencao;
        protected bool EstaCompleto;

        public InterfaceDoUsuario()
        {
            EstaCompleto = true;
        }

        void Iniciar()
        {
            if (_fonteDeAguaQuente.EstaPronto && _recipienteDeContencao.EstaPronto)
            {
                EstaCompleto = false;
                _fonteDeAguaQuente.Inicia();
                _recipienteDeContencao.Inicia();
            }
        }

        protected internal void ConcluaPreparo()
        {
            EstaCompleto = true;
            ConcluirPreparo();
        }

        private protected abstract void ConcluirPreparo();
        protected internal abstract void Finaliza();
    }
}

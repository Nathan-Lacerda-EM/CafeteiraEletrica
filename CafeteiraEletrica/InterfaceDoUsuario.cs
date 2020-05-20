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


        void Iniciar()
        {
            if (_fonteDeAguaQuente.EstaPronto && _recipienteDeContencao.EstaPronto)
            {
                _fonteDeAguaQuente.IniciarPreparo();
                _recipienteDeContencao.IniciarPreparo();
            }
        }

        protected internal void ConcluirPreparo()
        {
            ConcluaPreparo();
        }

        private protected abstract void ConcluaPreparo();
        protected internal abstract void Finaliza();
    }
}

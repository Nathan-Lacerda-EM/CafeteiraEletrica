using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    class InterfaceDoUsuario
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private RecipienteDeContencao _recipienteDeContencao;

        void Preparar()
        {
            if (_fonteDeAguaQuente.EstaPronto && _recipienteDeContencao.EstaPronto)
            {
                _fonteDeAguaQuente.Inicie();
                _recipienteDeContencao.Inicie();
            }
        }

        internal void ConcluaPreparo()
        {
            throw new NotImplementedException();
        }

        internal void Finaliza()
        {
            throw new NotImplementedException();
        }
    }
}

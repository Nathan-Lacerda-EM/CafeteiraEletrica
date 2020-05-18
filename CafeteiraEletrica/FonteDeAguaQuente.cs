using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    class FonteDeAguaQuente
    {
        private RecipienteDeContencao _recipienteDeContencao;
        private InterfaceDoUsuario _interfaceDoUsuario;

        void ConcluirPreparo()
        {
            _recipienteDeContencao.ConcluaPreparo();
            _interfaceDoUsuario.ConcluaPreparo();
        }

        internal bool EstaPronto { get; set; }

        internal void Inicia()
        {
            throw new NotImplementedException();
        }

        internal void SuspendaFluxoDeAgua()
        {
            throw new NotImplementedException();
        }

        internal void RetomeFluxoDeAgua()
        {
            throw new NotImplementedException();
        }

        internal void ConcluaPreparo()
        {
            throw new NotImplementedException();
        }
    }
}

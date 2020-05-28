using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    public abstract class RecipienteDeContencao
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private InterfaceDoUsuario _interfaceDoUsuario;
        protected internal bool EstaPreparando;
        protected internal bool CicloCompleto;
        protected internal abstract bool EstaPronto { get; }

        public RecipienteDeContencao()
        {
            EstaPreparando = false;
            CicloCompleto = true;
        }

        public void Iniciar(InterfaceDoUsuario interfaceDoUsuario, FonteDeAguaQuente fonteDeAguaQuente)
        {
            _interfaceDoUsuario = interfaceDoUsuario;
            _fonteDeAguaQuente = fonteDeAguaQuente;
        }

        public void Completar()
        {
            Parar();
            CicloCompleto = true;
            _interfaceDoUsuario.FinalizarCiclo();
        }

        public void CafePronto()
        {
            EstaPreparando = false;
        }

        public void IniciarPreparo()
        {
            EstaPreparando = true;
            CicloCompleto = false;
        }

        public void PararFonte()
        {
            _fonteDeAguaQuente.Parar();
        }
        public void ContinuarFonte()
        {
            _fonteDeAguaQuente.Continuar();
        }

        public abstract void Parar();
        public abstract void Continuar();
    }
}

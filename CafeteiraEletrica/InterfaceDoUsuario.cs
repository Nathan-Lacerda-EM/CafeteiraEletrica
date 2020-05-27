﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteiraEletrica
{
    public abstract class InterfaceDoUsuario
    {
        private FonteDeAguaQuente _fonteDeAguaQuente;
        private RecipienteDeContencao _recipienteDeContencao;
        protected internal bool CicloCompleto;

        public InterfaceDoUsuario()
        {
            CicloCompleto = false;
        }

        public void Iniciar(FonteDeAguaQuente fonteDeAguaQuente, RecipienteDeContencao recipienteDeContencao)
        {
            _fonteDeAguaQuente = fonteDeAguaQuente;
            _recipienteDeContencao = recipienteDeContencao;
        }

        public void Preparar()
        {
            if (_fonteDeAguaQuente.EstaPronto && _recipienteDeContencao.EstaPronto)
            {
                _fonteDeAguaQuente.Preparar();
                _recipienteDeContencao.Preparar();
                CicloCompleto = false;
            }
        }

        public abstract void FinalizarCiclo();
        public abstract void Pronto();
    }
}

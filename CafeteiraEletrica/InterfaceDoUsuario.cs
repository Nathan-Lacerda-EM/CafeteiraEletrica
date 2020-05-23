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

        public void Inicia(FonteDeAguaQuente fonteDeAguaQuente, RecipienteDeContencao recipienteDeContencao)
        {
            _fonteDeAguaQuente = fonteDeAguaQuente;
            _recipienteDeContencao = recipienteDeContencao;
        }

        protected void Iniciar()
        {
            if (_fonteDeAguaQuente.EstaPronto && _recipienteDeContencao.EstaPronto)
            {
                _fonteDeAguaQuente.Preparar();
                _recipienteDeContencao.Preparar();
            }
        }
    }
}

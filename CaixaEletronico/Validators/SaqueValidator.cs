using CaixaEletronico.Enums;
using System;
using System.Collections.Generic;

namespace CaixaEletronico.Validators
{
    public static class SaqueValidator
    {
        public static bool PossuiNotasDisponiveis(int valor, List<CedulaEnum> notasDisponiveis)
        {
            if (valor == 0)
                return true;

            notasDisponiveis.ForEach(cedula => valor = (valor % (int)cedula));

            return valor == 0;
        }
    }
}

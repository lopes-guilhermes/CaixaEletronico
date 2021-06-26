using CaixaEletronico.Enums;
using System;
using System.Collections.Generic;

namespace CaixaEletronico.Validators
{
    public static class ValidarNotasDisponiveisParaSaque
    {
        public static bool Validar(int valor, List<CedulaEnum> notasDisponiveis)
        {
            if (valor == 0)
                return true;

            notasDisponiveis.ForEach(cedula => valor = (valor % (int)cedula));

            return valor == 0;
        }
    }
}

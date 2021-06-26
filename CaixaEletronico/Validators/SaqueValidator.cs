using CaixaEletronico.Enums;
using System;
using System.Collections.Generic;

namespace CaixaEletronico.Validators
{
    public static class SaqueValidator
    {
        public static bool PossuiNotasDisponiveis(int valor, List<CedulaEnum> notasDisponiveis)
        {
            if (valor == 0 || notasDisponiveis.Count == 0)
                return false;

            foreach (CedulaEnum cedula in notasDisponiveis)
            {
                if (PossuiNotasParaSaque(valor, cedula, notasDisponiveis))
                    continue;
                
                valor = (valor % (int)cedula);
            }
 
            return valor == 0;
        }

        public static bool PossuiNotasParaSaque(int valor, CedulaEnum cedula, List<CedulaEnum> notasDisponiveis)
        {
            return notasDisponiveis.Contains(CedulaEnum.Dois)
                && cedula == CedulaEnum.Cinco
                && (valor % (int)CedulaEnum.Dois == 0);
        }
    }
}

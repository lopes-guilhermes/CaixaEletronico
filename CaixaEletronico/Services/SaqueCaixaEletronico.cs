using CaixaEletronico.Enums;
using CaixaEletronico.Exceptions;
using CaixaEletronico.Models;
using CaixaEletronico.Providers.Interfaces;
using CaixaEletronico.Validators;
using System;
using System.Collections.Generic;

namespace CaixaEletronico.Services
{
    public class SaqueCaixaEletronico
    {
        private readonly INotasDisponiveisProvider _notasDisponiveisProvider;

        public SaqueCaixaEletronico(INotasDisponiveisProvider notasDisponiveisProvider) =>
            _notasDisponiveisProvider = notasDisponiveisProvider;

        public List<Saque> Sacar(int valor)
        {
            var saque = new List<Saque> { };
            var notasDisponiveis = _notasDisponiveisProvider.GetCedulasDisponiveis();

            //Garantir que as notas estão ordenadas da maior para a menor
            notasDisponiveis.Sort((CedulaEnum x, CedulaEnum y) => (int)y - (int)x);

            if (!SaqueValidator.PossuiNotasDisponiveis(valor, notasDisponiveis)) 
                throw new BusinessException("Não possui notas disponíveis para realizar o saque");

            foreach (CedulaEnum cedula in notasDisponiveis)
            {
                if (SaqueValidator.PossuiNotasParaSaque(valor, cedula, notasDisponiveis))
                    continue;

                var quantidade = (valor / (int)cedula);

                if (quantidade > 0)
                {
                    saque.Add(new Saque (quantidade, cedula));
                    valor -= quantidade * (int)cedula;
                }
            }

            return saque;
        }
    }
}

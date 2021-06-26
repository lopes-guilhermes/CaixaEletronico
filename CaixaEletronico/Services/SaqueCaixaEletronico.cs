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
            var notasDispoiniveis = _notasDisponiveisProvider.GetCedulasDisponiveis();

            if (!SaqueValidator.PossuiNotasDisponiveis(valor, notasDispoiniveis)) 
                throw new BusinessException("Não possui notas disponíveis para realizar o saque");
    
            notasDispoiniveis.ForEach(cedula =>
            {
                var quantidade = (valor / (int)cedula);
                
                if (quantidade > 0)
                {
                    saque.Add(new Saque (quantidade, cedula));
                    valor -= quantidade * (int)cedula;
                }
            });

            return saque;
        }
    }
}

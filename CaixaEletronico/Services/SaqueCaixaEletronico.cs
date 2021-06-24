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

            if (!ValidarNotasDisponiveisParaSaque.Validar(valor, notasDispoiniveis)) 
                throw new Exception("Não possui notas disponíveis para realizar o saque");
                        
            /// separar cédulas            

            return saque;
        }
    }
}

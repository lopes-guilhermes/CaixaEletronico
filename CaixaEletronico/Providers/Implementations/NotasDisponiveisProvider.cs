using CaixaEletronico.Enums;
using CaixaEletronico.Providers.Interfaces;
using System.Collections.Generic;

namespace CaixaEletronico.Providers.Implementations
{
    internal class NotasDisponiveisProvider : INotasDisponiveisProvider
    {
        public List<CedulaEnum> GetCedulasDisponiveis()
        {
            var cedulasDisponiveis = new List<CedulaEnum> { CedulaEnum.Cem, CedulaEnum.Cinquenta, CedulaEnum.Vinte };

            return cedulasDisponiveis;
        }
    }
}

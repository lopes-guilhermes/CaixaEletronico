using CaixaEletronico.Enums;
using CaixaEletronico.Providers.Interfaces;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace CaixaEletronico.Providers.Implementations
{
    internal class NotasDisponiveisProvider : INotasDisponiveisProvider
    {
        ObjectCache cache = MemoryCache.Default;
        public List<CedulaEnum> GetCedulasDisponiveis()
        {
            var cedulasDisponiveis = (List<CedulaEnum>)cache.Get("_NotasDisponiveis");

            return cedulasDisponiveis;
        }
    }
}

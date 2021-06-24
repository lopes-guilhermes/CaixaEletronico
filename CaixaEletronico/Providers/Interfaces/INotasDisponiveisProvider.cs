using CaixaEletronico.Enums;
using System.Collections.Generic;

namespace CaixaEletronico.Providers.Interfaces
{
    public interface INotasDisponiveisProvider
    {
        List<CedulaEnum> GetCedulasDisponiveis();
    }
}

using CaixaEletronico.Enums;
using CaixaEletronico.Providers.Interfaces;
using System.Collections.Generic;

namespace TestCaixaEletronico.Mocks
{
    public class MockNotasDisponiveisProvider : INotasDisponiveisProvider
    {
        public List<CedulaEnum> cedulasDisponiveis { get; set; }

        public List<CedulaEnum> GetCedulasDisponiveis() => cedulasDisponiveis;


    }
}

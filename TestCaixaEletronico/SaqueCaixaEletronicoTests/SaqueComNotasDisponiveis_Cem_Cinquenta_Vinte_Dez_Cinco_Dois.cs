using CaixaEletronico.Enums;
using CaixaEletronico.Providers.Interfaces;
using CaixaEletronico.Services;
using NUnit.Framework;
using System.Collections.Generic;
using TestCaixaEletronico.Mocks;

namespace TestCaixaEletronico.SaqueCaixaEletronicoTests
{
    public class SaqueComNotasDisponiveis_Cem_Cinquenta_Vinte_Dez_Cinco_Dois
    {

        private SaqueCaixaEletronico _saqueCaixaEletronico;
        private INotasDisponiveisProvider _notasDisponiveisProvider;

        [SetUp]
        public void Setup()
        {
            _notasDisponiveisProvider = new MockNotasDisponiveisProvider
            {
                cedulasDisponiveis = new List<CedulaEnum> {
                    CedulaEnum.Cem,
                    CedulaEnum.Cinquenta,
                    CedulaEnum.Vinte,
                    CedulaEnum.Dez,
                    CedulaEnum.Cinco,
                    CedulaEnum.Dois
                }
            };

            _saqueCaixaEletronico = new SaqueCaixaEletronico(_notasDisponiveisProvider);
        }

        [Test]
        public void SacarComSucesso()
        {
            Assert.Pass();
        }

        [Test]
        public void SacarComValorNotasIndisponiveis()
        {
            Assert.Pass();
        }
    }
}

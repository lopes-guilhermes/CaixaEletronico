using CaixaEletronico.Enums;
using CaixaEletronico.Exceptions;
using CaixaEletronico.Providers.Interfaces;
using CaixaEletronico.Services;
using NUnit.Framework;
using System.Collections.Generic;
using TestCaixaEletronico.Mocks;

namespace TestCaixaEletronico.SaqueCaixaEletronicoTests
{
    public class SaqueComNotasDisponiveis_Cem_Cinquenta_Vinte
    {
        private SaqueCaixaEletronico _saqueCaixaEletronico;
        private INotasDisponiveisProvider _notasDisponiveisProvider;

        [SetUp]
        public void Setup()
        {
            _notasDisponiveisProvider = new MockNotasDisponiveisProvider{ 
                cedulasDisponiveis = new List<CedulaEnum> { 
                    CedulaEnum.Cem,
                    CedulaEnum.Cinquenta,
                    CedulaEnum.Vinte
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
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(1));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(5));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(19));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(130));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(80));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(60));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(75));
        }
    }
}

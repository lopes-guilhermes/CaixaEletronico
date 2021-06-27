using CaixaEletronico.Enums;
using CaixaEletronico.Exceptions;
using CaixaEletronico.Models;
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
                    CedulaEnum.Cinquenta,
                    CedulaEnum.Cem,
                    CedulaEnum.Vinte
                } 
            };

            _saqueCaixaEletronico = new SaqueCaixaEletronico(_notasDisponiveisProvider);
        }

        [Test]
        public void SacarComSucesso()
        {
            Assert.AreEqual(_saqueCaixaEletronico.Sacar(150), new List<Saque> {
                new Saque(1, CedulaEnum.Cem),
                new Saque(1, CedulaEnum.Cinquenta)
            });
            
            Assert.AreEqual(_saqueCaixaEletronico.Sacar(120), new List<Saque> {
                new Saque(1, CedulaEnum.Cem),
                new Saque(1, CedulaEnum.Vinte)
            });
            
            Assert.AreEqual(_saqueCaixaEletronico.Sacar(170), new List<Saque> {
                new Saque(1, CedulaEnum.Cem),
                new Saque(1, CedulaEnum.Cinquenta),
                new Saque(1, CedulaEnum.Vinte)
            });
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

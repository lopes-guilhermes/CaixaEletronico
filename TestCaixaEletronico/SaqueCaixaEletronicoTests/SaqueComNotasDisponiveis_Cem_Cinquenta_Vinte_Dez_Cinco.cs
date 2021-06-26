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
    public class SaqueComNotasDisponiveis_Cem_Cinquenta_Vinte_Dez_Cinco
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
                    CedulaEnum.Cinco
                }
            };

            _saqueCaixaEletronico = new SaqueCaixaEletronico(_notasDisponiveisProvider);
        }

        [Test]
        public void SacarComSucesso()
        {

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(175), new List<Saque> {
                new Saque(1, CedulaEnum.Cem),
                new Saque(1, CedulaEnum.Cinquenta),
                new Saque(1, CedulaEnum.Vinte),
                new Saque(1, CedulaEnum.Cinco)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(110), new List<Saque> {
                new Saque(1, CedulaEnum.Cem),
                new Saque(1, CedulaEnum.Dez)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(80), new List<Saque> {  
                new Saque(1, CedulaEnum.Cinquenta),
                new Saque(1, CedulaEnum.Vinte),
                new Saque(1, CedulaEnum.Dez)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(75), new List<Saque> {
                new Saque(1, CedulaEnum.Cinquenta),
                new Saque(1, CedulaEnum.Vinte),
                new Saque(1, CedulaEnum.Cinco)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(105), new List<Saque> {
                new Saque(1, CedulaEnum.Cem),
                new Saque(1, CedulaEnum.Cinco)
            });
        }

        [Test]
        public void SacarComValorNotasIndisponiveis()
        {
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(1));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(42));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(102));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(199));
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(88));
        }
    }
}

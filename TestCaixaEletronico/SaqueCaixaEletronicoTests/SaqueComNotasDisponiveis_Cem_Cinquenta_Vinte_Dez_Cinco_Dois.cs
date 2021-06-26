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
            Assert.AreEqual(_saqueCaixaEletronico.Sacar(2), new List<Saque> {
                new Saque(1, CedulaEnum.Dois)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(7), new List<Saque> {  
                new Saque(1, CedulaEnum.Cinco),
                new Saque(1, CedulaEnum.Dois)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(15), new List<Saque> {
                new Saque(1, CedulaEnum.Dez),
                new Saque(1, CedulaEnum.Cinco)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(77), new List<Saque> {
                new Saque(1, CedulaEnum.Cinquenta),
                new Saque(1, CedulaEnum.Vinte),
                new Saque(1, CedulaEnum.Dois)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(99), new List<Saque> {
                new Saque(1, CedulaEnum.Cinquenta),
                new Saque(2, CedulaEnum.Vinte),
                new Saque(1, CedulaEnum.Cinco),
                new Saque(2, CedulaEnum.Dois)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(88), new List<Saque> {
                new Saque(1, CedulaEnum.Cinquenta),
                new Saque(1, CedulaEnum.Vinte),
                new Saque(1, CedulaEnum.Dez),
                new Saque(4, CedulaEnum.Dois)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(150), new List<Saque> {
                new Saque(1, CedulaEnum.Cem),
                new Saque(1, CedulaEnum.Cinquenta)
            });

            Assert.AreEqual(_saqueCaixaEletronico.Sacar(380), new List<Saque> {
                new Saque(3, CedulaEnum.Cem),
                new Saque(1, CedulaEnum.Cinquenta),
                new Saque(1, CedulaEnum.Vinte),
                new Saque(1, CedulaEnum.Dez)
            });
        }

        [Test]
        public void SacarComValorNotasIndisponiveis()
        {
            Assert.Throws<BusinessException>(() => _saqueCaixaEletronico.Sacar(1));
        }
    }
}

using CaixaEletronico.Enums;
using CaixaEletronico.Exceptions;
using CaixaEletronico.Factories;
using CaixaEletronico.Providers.Implementations;
using CaixaEletronico.Providers.Interfaces;
using CaixaEletronico.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            int valorSaque;
            int opcaoMenu;
            
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) => services.AddSingleton<INotasDisponiveisProvider, NotasDisponiveisProvider>())
                .Build();

            Console.WriteLine("######## Saque Caixa Eletrônico ########");
            do
            {
                Console.WriteLine();
                Console.WriteLine("0 -> Encerrar");
                Console.WriteLine("1 -> Notas Disponíveis: [100, 50, 20]");
                Console.WriteLine("2 -> Notas Disponíveis: [100, 50, 20, 10, 5]");
                Console.WriteLine("3 -> Notas Disponíveis: [100, 50, 20, 10, 5, 2]");
                
                Console.Write("Selecione uma opção:");
                while (!int.TryParse(Console.ReadLine(), out opcaoMenu) || (opcaoMenu < 0 || opcaoMenu > 3))
                    Console.Write("Selecione uma opção válida:");

                if (opcaoMenu == 0)
                    continue;

                ConfigurarServicoNotasDisponiveis(opcaoMenu);

                Console.Write("Digite o valor para desejado:");
                while (!int.TryParse(Console.ReadLine(), out valorSaque))
                    Console.Write("Digite um valor inteiro válido:");

                try
                {
                    var serviceFactory = new ServiceFactory(host.Services);
                    var caixaEletronico = serviceFactory.GetService<SaqueCaixaEletronico>();
                    
                    var saque = caixaEletronico.Sacar(valorSaque);

                    Console.WriteLine("Saque realizado:");
                    Console.WriteLine(String.Join(", ", saque));
                } 
                catch (BusinessException error)
                {
                    Console.WriteLine(error.Message);
                    Console.WriteLine("Tente Novamente");
                }
                catch (Exception error) 
                {
                    opcaoMenu = 0;
                    Console.WriteLine(error.Message);
                    Console.WriteLine("A Aplicação apresentou um erro inesperado e será encerrada!");
                    Console.WriteLine();
                }

            } while (opcaoMenu != 0);
        }

        static void ConfigurarServicoNotasDisponiveis(int opcao)
        {
            ObjectCache cache = MemoryCache.Default;
            Dictionary<int, List<CedulaEnum>> notasDisponiveis = new Dictionary<int, List<CedulaEnum>>();

            notasDisponiveis.Add(1, new List<CedulaEnum> { CedulaEnum.Cem, CedulaEnum.Cinquenta, CedulaEnum.Vinte });
            notasDisponiveis.Add(2, new List<CedulaEnum> { CedulaEnum.Cem, CedulaEnum.Cinquenta, CedulaEnum.Vinte, CedulaEnum.Dez, CedulaEnum.Cinco });
            notasDisponiveis.Add(3, new List<CedulaEnum> { CedulaEnum.Cem, CedulaEnum.Cinquenta, CedulaEnum.Vinte, CedulaEnum.Dez, CedulaEnum.Cinco, CedulaEnum.Dois });

            cache.Set("_NotasDisponiveis", notasDisponiveis[opcao], new CacheItemPolicy());
        }

    }
}

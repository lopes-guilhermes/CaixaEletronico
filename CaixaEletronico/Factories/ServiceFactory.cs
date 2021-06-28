using CaixaEletronico.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using CaixaEletronico.Providers.Interfaces;

namespace CaixaEletronico.Factories
{
    public class ServiceFactory
    {
        private Dictionary<object, object> services;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            services = new Dictionary<object, object>();
            services.Add(
                typeof(SaqueCaixaEletronico), 
                new SaqueCaixaEletronico(serviceProvider.GetRequiredService<INotasDisponiveisProvider>()));
        }

        public T GetService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("Serviço não registrado.");
            }
        }
    }
}

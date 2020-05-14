using System;
using System.Linq;
using System.Reflection;
using Mediator.Behaviors.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Abstractions.Interfaces;

namespace Mediator.DependencyRegistration
{
    public class MediatorBuilder : IMediatorBuilder
    {
        private readonly IServiceCollection _services;

        public MediatorBuilder(IServiceCollection services, params Assembly[] assemblies)
        {
            _services = services;

            RegisterMediator(assemblies);
        }

        public IMediatorBuilder WithPersistableBehavior()
        {
            if (_services.All(n => n.ServiceType != typeof(IDataUnitOfWork)))
            {
                throw new InvalidOperationException(
                    $"You must register {nameof(IDataUnitOfWork)} before registering {typeof(PersistableBehavior<,>).Name}.");
            }

            _services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PersistableBehavior<,>));

            return this;
        }

        private void RegisterMediator(params Assembly[] assemblies)
        {
            _services.AddMediatR(assemblies);
        }
    }
}

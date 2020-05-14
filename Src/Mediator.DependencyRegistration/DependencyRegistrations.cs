using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.DependencyRegistration
{
    public static class DependencyRegistrations
    {
        public static IServiceCollection RegisterMediator(
            this IServiceCollection services,
            Assembly[] assemblies,
            Action<IMediatorBuilder> action = null)
        {
            var mediatorBuilder = new MediatorBuilder(services, assemblies);

            action?.Invoke(mediatorBuilder);

            return services;
        }
    }
}

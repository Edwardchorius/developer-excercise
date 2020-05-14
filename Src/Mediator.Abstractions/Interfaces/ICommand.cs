
using MediatR;

namespace Mediator.Abstractions.Interfaces
{
    public interface ICommand<out T> : IRequest<T>
    {
    }
}

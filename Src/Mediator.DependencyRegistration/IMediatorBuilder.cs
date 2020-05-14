using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator.DependencyRegistration
{
    public interface IMediatorBuilder
    {
        IMediatorBuilder WithPersistableBehavior();
    }
}

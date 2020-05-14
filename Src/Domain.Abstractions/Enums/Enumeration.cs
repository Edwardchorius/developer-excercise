
using Ardalis.SmartEnum;

namespace Domain.Abstractions.Enums
{
    public abstract class Enumeration<TEnum> : SmartEnum<TEnum>
        where TEnum : SmartEnum<TEnum, int>
    {
        protected Enumeration(string name, int value)
            : base(name, value)
        {

        }
    }
}

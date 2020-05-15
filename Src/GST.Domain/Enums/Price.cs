


using Domain.Abstractions.Enums;

namespace GST.Domain.Enums
{
    public class Price : Enumeration<Price>
    {
        public static Price Aws() => new Price(nameof(Price.Aws), 1);
        public static Price Cloud() => new Price(nameof(Price.Cloud), 100);
        protected Price(string name, int value)
            : base(name, value)
        {

        }
    }
}

using System;

namespace GreedGameRules
{
    internal class DisplayAttribute : Attribute
    {
        private readonly string v;

        public DisplayAttribute(string v)
        {
            this.v = v;
        }

        public override string ToString()
        {
            return v;
        }
    }
}
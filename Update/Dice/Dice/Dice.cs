using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public abstract class Dice<T> : IDice<T>
    {
        private Dice() { }

        protected Dice(T value) => Value = value;

        public T Value { get; }
    }
}

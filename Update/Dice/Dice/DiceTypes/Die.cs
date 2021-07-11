using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DiceTypes
{
    public abstract class Die<T> : IDie<T>
    {
        private Die() { }

        protected Die(T value) => Value = value;

        public T Value { get; }
    }
}

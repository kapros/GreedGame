using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.DiceTypes
{
    public class RegularDie : Die<RegularDieResult>
    {
        public RegularDie(RegularDieResult result) : base(result)
        { }

        public static RegularDie FromDiceRoll(RegularDieResult result) => new(result);

        public override bool Equals(object obj)
            => obj is RegularDie other && other.Value.Equals(Value);

        public override int GetHashCode()
            => HashCode.Combine((int)Value, ToString());

        public override string ToString()
            => Value.ToString();
    }
}

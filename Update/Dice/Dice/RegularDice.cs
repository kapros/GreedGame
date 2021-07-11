using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class RegularDice : Dice<RegularDiceResult>
    {
        public RegularDice(RegularDiceResult result) : base(result)
        { }

        public static RegularDice FromDiceRoll(RegularDiceResult result) => new(result);

        public override bool Equals(object obj)
            => obj is RegularDice other && other.Value.Equals(Value);

        public override int GetHashCode()
            => HashCode.Combine((int)Value, ToString());

        public override string ToString()
            => Value.ToString();
    }
}

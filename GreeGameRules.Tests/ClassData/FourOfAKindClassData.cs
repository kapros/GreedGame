using GreedGameRules;
using System.Collections;
using System.Collections.Generic;

namespace GreeGameRules.Tests.ClassData
{
    public class FourOfAKindClassData : IEnumerable<object[]>
    {
        private readonly IEnumerable<object[]> data = new List<object[]>()
        {
        new object[] { DieRoll.One },
        new object[] { DieRoll.Two },
        new object[] { DieRoll.Three },
        new object[] { DieRoll.Four },
        new object[] { DieRoll.Five },
        new object[] { DieRoll.Six }
        };

        public IEnumerator<object[]> GetEnumerator() => data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

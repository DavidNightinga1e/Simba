using System.Collections.Generic;
using Simba;

namespace Simba.Example
{
    public class ExampleRunner : SystemRunner
    {
        protected override List<ISystem> Systems { get; } = new List<ISystem>
        {
            new FirstBehaviour(),
            new SecondBehaviour(),
            new ThirdBehaviour()
        };
    }
}
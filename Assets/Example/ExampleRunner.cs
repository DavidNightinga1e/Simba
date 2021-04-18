using System.Collections.Generic;
using Simba.OrderedBehaviour;

namespace Example
{
    public class ExampleRunner : OrderedBehaviourRunner
    {
        protected override List<IOrderedBehaviour> OrderedBehaviours { get; } = new List<IOrderedBehaviour>
        {
            new FirstBehaviour(),
            new SecondBehaviour(),
            new ThirdBehaviour()
        };
    }
}
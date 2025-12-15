using System;
using System.Collections.Generic;
using HECSFramework.Core;

namespace Components
{
    [Serializable]
    [Documentation(Doc.HECS, Doc.Counters, "here we hold just counters without componets to add them to counters holder, we need use it if we want operate counters and resources and save them between sessions, otherwise better use counters holder directly")]
    public class CompositeCountersComponent : BaseComponent, ISavebleComponent
    {
        [Field(0)]
        public List<DefaultIntCounter> IntCounters = new List<DefaultIntCounter>(0);

        [Field(1)]
        public List<DefaultFloatCounter> FloatCounters = new List<DefaultFloatCounter>(0);

        public override void AfterInit()
        {
            foreach (var counter in IntCounters)
            {
                Owner.GetComponent<CountersHolderComponent>().AddCounter(counter);
            }

            foreach (var counter in FloatCounters)
            {
                Owner.GetComponent<CountersHolderComponent>().AddCounter(counter);
            }
        }
    }
}
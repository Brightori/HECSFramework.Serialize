using System;
using System.Collections.Generic;
using HECSFramework.Core;
using HECSFramework.Serialize;
using MessagePack;

namespace Components
{
    [Serializable]
    [Documentation(Doc.HECS, Doc.Counters, "here we hold just counters without componets to add them to counters holder, we need use it if we want operate counters and resources and save them between sessions, otherwise better use counters holder directly")]
    public class CompositeCountersComponent : BaseComponent, ISavebleComponent
    {
        [Field(0, typeof(DefaultIntCounterListResolver))]
        public List<DefaultIntCounter> IntCounters = new List<DefaultIntCounter>(0);

        [Field(1, typeof(DefaultFloatCounterListResolver))]
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

    [MessagePackObject]
    public struct DefaultFloatCounterListResolver : IResolver<DefaultFloatCounterListResolver, List<DefaultFloatCounter>>
    {
        [Key(0)]
        public List<FloatToID> FloatToIDs;

        public DefaultFloatCounterListResolver In(ref List<DefaultFloatCounter> data)
        {
            FloatToIDs = new List<FloatToID>(data.Count);

            foreach (var counter in data)
            {
                FloatToIDs.Add(new FloatToID { ID = counter.Id, Value = counter.Value });
            }

            return this;
        }

        public void Out(ref List<DefaultFloatCounter> data)
        {
            data.Clear();

            foreach (var counter in FloatToIDs)
            {
                data.Add(new DefaultFloatCounter(counter.Value, counter.ID));
            }
        }
    }

    [MessagePackObject]
    public struct DefaultIntCounterListResolver : IResolver<DefaultIntCounterListResolver, List<DefaultIntCounter>>
    {
        [Key(0)]
        public List<IntToID> FloatToIDs;

        public DefaultIntCounterListResolver In(ref List<DefaultIntCounter> data)
        {
            FloatToIDs = new List<IntToID>(data.Count);

            foreach (var counter in data)
            {
                FloatToIDs.Add(new IntToID { ID = counter.Id, Value = counter.Value });
            }

            return this;
        }

        public void Out(ref List<DefaultIntCounter> data)
        {
            data.Clear();

            foreach (var counter in FloatToIDs)
            {
                data.Add(new DefaultIntCounter(counter.Value, counter.ID));
            }
        }
    }

    [MessagePackObject]
    public struct FloatToID
    {
        [Key(0)]
        public float Value;

        [Key(1)]
        public int ID;
    }

    [MessagePackObject]
    public struct IntToID
    {
        [Key(0)]
        public int Value;

        [Key(1)]
        public int ID;
    }
}
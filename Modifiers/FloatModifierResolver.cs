using System;
using HECSFramework.Core;
using MessagePack;

namespace HECSFramework.Serialize
{
    [MessagePackObject]
    public struct FloatModifierResolver
    {
        [Key(0)]
        public int ModifierType;

        [Key(1)]
        public float Value;

        [Key(2)]
        public Guid Guid;

        [Key(3)]
        public int CounterID;

        public FloatModifierResolver(IModifier<float> modifier)
        {
            ModifierType = modifier.ModifierType;
            Value = modifier.GetValue;
            Guid = modifier.ModifierGuid;
            CounterID = modifier.ModifierCounterID;
        }
    }
}
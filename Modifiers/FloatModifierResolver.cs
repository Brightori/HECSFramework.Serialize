using System;
using HECSFramework.Core;
using MessagePack;

namespace HECSFramework.Serialize
{
    [MessagePackObject]
    public struct FloatModifierResolver
    {
        [Key(0)]
        public int Index;

        [Key(1)]
        public float Value;

        [Key(2)]
        public Guid Guid;

        public FloatModifierResolver(IModifier<float> modifier)
        {
            Index = modifier.ModifierID;
            Value = modifier.GetValue;
            Guid = modifier.ModifierGuid;
        }
    }
}
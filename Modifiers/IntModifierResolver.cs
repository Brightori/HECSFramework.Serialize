using System;
using HECSFramework.Core;
using MessagePack;

namespace HECSFramework.Serialize
{
    [MessagePackObject]
    public struct IntModifierResolver
    {
        [Key(0)]
        public int Index;

        [Key(1)]
        public int Value;

        [Key(2)]
        public Guid Guid;

        public IntModifierResolver(IModifier<int> modifier)
        {
            Index = modifier.ModifierID;
            Value = modifier.GetValue;
            Guid = modifier.ModifierGuid;
        }
    }
}
using HECSFramework.Core;

namespace HECSFramework.Serialize
{
    public abstract class IntModifierProcessor
    {
        public abstract IModifier<int> GetModifier(IntModifierResolver floatModifierResolver);
    }
}

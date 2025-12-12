using HECSFramework.Core;

namespace HECSFramework.Serialize
{
    public abstract class FloatModifierProcessor
    {
        public abstract IModifier<float> GetModifier(FloatModifierResolver floatModifierResolver);
    }
}

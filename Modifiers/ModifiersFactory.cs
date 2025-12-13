using System.Collections.Generic;
using Commands;
using HECSFramework.Core;

namespace HECSFramework.Serialize
{
    public class ModifiersFactory
    {
        private Dictionary<int, FloatModifierProcessor> floatModifiersProcessors = new Dictionary<int, FloatModifierProcessor>(4);
        private Dictionary<int, IntModifierProcessor> intModifiersProcessors = new Dictionary<int, IntModifierProcessor>(4);

        public void AddFloatProcess(int index, FloatModifierProcessor modifierFloatProcessor)
        {
            floatModifiersProcessors[index] = modifierFloatProcessor;
        }

        public void AddIntProcess(int index, IntModifierProcessor modifierFloatProcessor)
        {
            intModifiersProcessors[index] = modifierFloatProcessor;
        }

        public void ProcessFloatModifierResolver(Entity entity, FloatModifierResolver floatModifierResolver, bool isUnique = false)
        {
            if (floatModifiersProcessors.TryGetValue(floatModifierResolver.ModifierType,
                out FloatModifierProcessor modifierFloatProcessor))
            {
                var modifier = modifierFloatProcessor.GetModifier(floatModifierResolver);

                entity.Command(new AddCounterModifierCommand<float>
                {
                    Id = modifier.ModifierCounterID,
                    IsUnique = isUnique,
                    Modifier = modifier,
                    Owner = entity.GUID
                });
            }
        }

        public void ProcessIntModifierResolver(Entity entity, IntModifierResolver intModifierResolver, bool isUnique = false)
        {
            if (intModifiersProcessors.TryGetValue(intModifierResolver.ModifierType,
                out IntModifierProcessor modifierFloatProcessor))
            {
                var modifier = modifierFloatProcessor.GetModifier(intModifierResolver);

                entity.Command(new AddCounterModifierCommand<int>
                {
                    Id = modifier.ModifierCounterID,
                    IsUnique = isUnique,
                    Modifier = modifier,
                    Owner = entity.GUID
                });
            }
        }

        public IModifier<float> ProcessFloatModifierResolver(FloatModifierResolver floatModifierResolver, bool isUnique = false)
        {
            if (floatModifiersProcessors.TryGetValue(floatModifierResolver.ModifierType,
                out FloatModifierProcessor modifierFloatProcessor))
            {
                return modifierFloatProcessor.GetModifier(floatModifierResolver);
            }

            return null;
        }

        public IModifier<int> ProcessFloatModifierResolver(IntModifierResolver floatModifierResolver, bool isUnique = false)
        {
            if (intModifiersProcessors.TryGetValue(floatModifierResolver.ModifierType,
                out IntModifierProcessor modifierFloatProcessor))
            {
                return modifierFloatProcessor.GetModifier(floatModifierResolver);
            }

            return null;
        }
    }
}

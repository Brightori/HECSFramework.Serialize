using System.Collections.Generic;
using HECSFramework.Core;

namespace HECSFramework.Serialize
{
    [Documentation(Doc.HECS, Doc.Animation, "this component holds animation state and links identifiers id to AnimatorHashID")]
    public partial class AnimatorState : ISaveToResolver<AnimatorStateResolver>, ILoadFromResolver<AnimatorStateResolver>
    {
        private Dictionary<int, bool> boolParameters = new Dictionary<int, bool>();
        private Dictionary<int, float> floatParameters = new Dictionary<int, float>();

        public int AnimatorID { get; protected set; }


        public void SetBool(int id, bool value)
        {
            boolParameters[id]= value;
            SetBoolUnityPart(id, value);
        }

        partial void SetBoolUnityPart(int id, bool value);

        public void SetFloat(int id, float value)
        {
            floatParameters[id] = value;
            SetFloatUnityPart(id, value);
        }
        partial void SetFloatUnityPart(int id, float value);

        public bool TryGetBool(int id ,out bool value)
        {
            return boolParameters.TryGetValue(id, out value);
        }

        public bool TryGetFloat(int id, out float value)
        {
            return floatParameters.TryGetValue(id, out value);
        }

        #region SaveLoad
        public void Load(ref AnimatorStateResolver resolver)
        {
            foreach (var bp in resolver.BoolStates)
                boolParameters[bp.Key] = bp.Value.Value;

            foreach (var bp in resolver.FloatStates)
                floatParameters[bp.Key] = bp.Value.Value;

            AnimatorID = resolver.AnimatorID;
        }

        public void Save(ref AnimatorStateResolver resolver)
        {
            resolver.BoolStates.Clear();
            resolver.FloatStates.Clear();

            foreach (var bp in boolParameters)
                resolver.BoolStates.Add(bp.Key, new BoolParameterResolver { Value = bp.Value });

            foreach (var bp in floatParameters)
                resolver.FloatStates.Add(bp.Key, new FloatParameterResolver { Value = bp.Value });

            resolver.AnimatorID = AnimatorID;
        }
        #endregion
    }
}
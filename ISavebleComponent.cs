using HECSFramework.Core;

namespace Components
{
    [Documentation(Doc.HECS, Doc.Serialization, "We mark components whom need to be in save file")]
    public interface ISavebleComponent
    {
    }

    [Documentation(Doc.HECS, Doc.Serialization, "We can mark object for logic purpose")]
    public interface IDirty
    {
        bool IsDirty { get; set; }
    }
}
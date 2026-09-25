namespace HECSFramework.Core
{
    public interface IResolverContainer : ITypeContainer
    {
        void RegisterResolvers(ResolversMap map);
    }
}

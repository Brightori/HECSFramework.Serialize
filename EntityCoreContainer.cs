using Components;

namespace HECSFramework.Core
{
    public abstract class EntityCoreContainer : IEntityContainer
    {
        public abstract string ContainerID { get; }

        public void Init(Entity entityForInit)
        {
            entityForInit.AddComponent(new ActorContainerID { ID = ContainerID });
            InitEntity(entityForInit);
        }

        protected abstract void InitEntity(Entity entity);
    }
}
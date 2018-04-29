namespace cln
{
    public sealed class CollisionSystems : Feature
    {
        public CollisionSystems(Contexts contexts)
        {
            Add(new ProcessCollisionSystem(contexts.game));
        }
    }
}
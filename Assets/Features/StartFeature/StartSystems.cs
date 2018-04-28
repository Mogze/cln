namespace cln
{
    public sealed class StartSystems : Feature
    {
        public StartSystems(Contexts contexts)
        {
            Add(new StartSystem(contexts.game));
        }
    }
}
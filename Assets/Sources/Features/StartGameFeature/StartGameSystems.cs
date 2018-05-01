namespace cln
{
    public sealed class StartGameSystems : Feature
    {
        public StartGameSystems(Contexts contexts)
        {
            Add(new StartSystem(contexts.game));
        }
    }
}
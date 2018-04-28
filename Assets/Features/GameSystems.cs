namespace cln
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new StartSystems(contexts));
            Add(new InputSystems(contexts));
            Add(new ViewSystems(contexts));
        }
    }
}
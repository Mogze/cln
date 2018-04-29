namespace cln
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new StartSystems(contexts));
            Add(new InputSystems(contexts));
            Add(new ViewSystems(contexts));
            Add(new PlaySystems(contexts));
            Add(new CollisionSystems(contexts));
            Add(new CameraSystems(contexts));
            Add(new ScoreSystems(contexts));
        }
    }
}
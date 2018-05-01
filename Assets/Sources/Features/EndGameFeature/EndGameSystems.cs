namespace cln
{
    public sealed class EndGameSystems : Feature
    {
        public EndGameSystems(Contexts contexts)
        {
            Add(new EndSystem(contexts.game));
        }
    }
}
namespace cln.Features
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new ViewSystems(contexts));
        }
    }
}
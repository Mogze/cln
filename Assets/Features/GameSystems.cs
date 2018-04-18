namespace cln
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new InputSystem());
            Add(new ViewSystems(contexts));
        }
    }
}
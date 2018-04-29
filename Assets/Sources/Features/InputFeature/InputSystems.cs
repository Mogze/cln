namespace cln
{
    public sealed class InputSystems : Feature
    {
        public InputSystems(Contexts contexts)
        {
            Add(new InputSystem(contexts.game));
            Add(new ProcessInputSystem(contexts.game));
        }
    }
}
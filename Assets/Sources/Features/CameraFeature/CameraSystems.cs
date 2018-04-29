namespace cln
{
    public sealed class CameraSystems : Feature
    {
        public CameraSystems(Contexts contexts)
        {
            Add(new CameraMoveSystem(contexts.game));
        }
    }
}
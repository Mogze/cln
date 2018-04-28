namespace cln
{
    public sealed class ViewSystems : Feature
    {
        public ViewSystems(Contexts contexts)
        {
            Add(new AddViewSystem(contexts.game));
            Add(new SetPositionSystem(contexts.game));
        }
    }
}
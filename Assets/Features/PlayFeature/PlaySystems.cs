namespace cln
{
    public sealed class PlaySystems : Feature
    {
        public PlaySystems(Contexts contexts)
        {
            Add(new JumpSystem(contexts.game));
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace cln
{
    public sealed class EndSystem: ReactiveSystem<GameEntity>
    {
        public EndSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.EndGame);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            
        }
    }
}
using System.Collections.Generic;
using Entitas;

namespace cln
{
    public class ProcessInputSystem : ReactiveSystem<GameEntity>
    {
        public ProcessInputSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Input);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                inputEntity.Destroy();
            }
        }
    }
}
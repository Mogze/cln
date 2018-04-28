using System.Collections.Generic;
using Entitas;

namespace cln
{
    public sealed class JumpSystem : ReactiveSystem<GameEntity>
    {
        public JumpSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public JumpSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            throw new System.NotImplementedException();
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new System.NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
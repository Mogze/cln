using System.Collections.Generic;
using Entitas;

namespace cln
{
    public sealed class ScoreSystem : ReactiveSystem<GameEntity>
    {
        private IContext<GameEntity> _context;

        public ScoreSystem(IContext<GameEntity> context) : base(context)
        {
            _context = context;
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
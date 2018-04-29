using System.Collections.Generic;
using Entitas;

namespace cln
{
    public class ProcessInputSystem : ReactiveSystem<GameEntity>
    {
        private IContext<GameEntity> _context;

        public ProcessInputSystem(IContext<GameEntity> context) : base(context)
        {
            _context = context;
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
                var cubeEntity = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
                if (!cubeEntity.hasVelocity)
                    cubeEntity.AddVelocity(GameConfig.JumpSpeed);
            }
        }
    }
}
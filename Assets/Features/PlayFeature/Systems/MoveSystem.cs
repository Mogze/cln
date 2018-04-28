using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class MoveSystem : IExecuteSystem
    {
        private IContext<GameEntity> _context;
        private IGroup<GameEntity> moveGroup;

        public MoveSystem(IContext<GameEntity> context)
        {
            _context = context;
            moveGroup = context.GetGroup(GameMatcher.Velocity);
        }

        public void Execute()
        {
            foreach (var moveEntity in moveGroup.GetEntities())
            {
                moveEntity.ReplacePosition(moveEntity.position.value + moveEntity.velocity.value * Time.deltaTime);
            }
        }
    }
}
using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class MoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _moveGroup;

        public MoveSystem(IContext<GameEntity> context)
        {
            _moveGroup = context.GetGroup(GameMatcher.Velocity);
        }

        public void Execute()
        {
            foreach (var moveEntity in _moveGroup.GetEntities())
            {
                moveEntity.ReplacePosition(moveEntity.position.value + moveEntity.velocity.value * Time.deltaTime);
            }
        }
    }
}
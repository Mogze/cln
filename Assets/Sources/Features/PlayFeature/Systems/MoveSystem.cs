using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class MoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> moveGroup;

        public MoveSystem(IContext<GameEntity> context)
        {
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
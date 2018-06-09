using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class GravitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cubeGroup;

        public GravitySystem(IContext<GameEntity> context)
        {
            _cubeGroup = context.GetGroup(GameMatcher.AllOf(GameMatcher.Cube, GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var cubeEntity in _cubeGroup.GetEntities())
            {
                cubeEntity.isGrounded = Physics.Linecast(cubeEntity.view.value.transform.position,
                    cubeEntity.view.value.transform.position + Vector3.down * 0.5f);
                if (!cubeEntity.isGrounded)
                    cubeEntity.ReplaceVelocity(cubeEntity.velocity.value + GameConfig.JumpDeceleration);
                else if (!cubeEntity.isJumping)
                {
                    cubeEntity.ReplaceVelocity(
                        new Vector3(cubeEntity.velocity.value.x, 0f, cubeEntity.velocity.value.z));
                }
            }
        }
    }
}
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
                var transform = cubeEntity.view.value.transform;
                cubeEntity.isGrounded = Physics.Linecast(transform.position + Vector3.right * 0.5f,
                    transform.position + Vector3.down * 0.52f);

                if (!cubeEntity.isGrounded)
                {
                    cubeEntity.ReplaceVelocity(cubeEntity.velocity.value + GameConfig.JumpDeceleration * Time.deltaTime);
                }
            }
        }
    }
}
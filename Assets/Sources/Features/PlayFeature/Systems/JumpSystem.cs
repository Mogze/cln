using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class JumpSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _cubeGroup;

        public JumpSystem(IContext<GameEntity> context)
        {
            _cubeGroup = context.GetGroup(GameMatcher.Cube);
        }

        public void Execute()
        {
            foreach (var cubeEntity in _cubeGroup.GetEntities())
            {
                if (cubeEntity.isJumping)
                {
                    cubeEntity.ReplaceVelocity(cubeEntity.velocity.value + GameConfig.JumpDeceleration * Time.deltaTime);
                    if (cubeEntity.position.value.y < -9f)
                    {
                        cubeEntity.isJumping = false;
                        cubeEntity.isDoubleJumping = false;
                        cubeEntity.ReplacePosition(new Vector3(cubeEntity.position.value.x, -9f, cubeEntity.position.value.z));
                        cubeEntity.ReplaceVelocity(new Vector3(cubeEntity.velocity.value.x, 0f,
                            cubeEntity.velocity.value.z));
                    }
                }
            }
        }
    }
}
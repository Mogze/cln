using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class JumpSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _cubeGroup;
        private Vector3 _jumpDecrease = new Vector3(0f, -60f, 0f);

        public JumpSystem(IContext<GameEntity> context)
        {
            _cubeGroup = context.GetGroup(GameMatcher.Cube);
        }

        public void Execute()
        {
            foreach (var cubeEntity in _cubeGroup.GetEntities())
            {
                if (cubeEntity.hasVelocity)
                    cubeEntity.ReplaceVelocity(cubeEntity.velocity.value + _jumpDecrease * Time.deltaTime);
            }
        }
    }
}
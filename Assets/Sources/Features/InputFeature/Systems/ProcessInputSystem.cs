using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class ProcessInputSystem : ReactiveSystem<GameEntity>
    {
        private readonly IContext<GameEntity> _context;

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
                if (!cubeEntity.isJumping)
                {
                    cubeEntity.ReplaceVelocity(cubeEntity.velocity.value + GameConfig.JumpVelocity - new Vector3(0f, cubeEntity.velocity.value.y, 0f));
                    cubeEntity.isJumping = true;
                }
                else if (!cubeEntity.isDoubleJumping)
                {
                    cubeEntity.ReplaceVelocity(cubeEntity.velocity.value + GameConfig.JumpVelocity - new Vector3(0f, cubeEntity.velocity.value.y, 0f));
                    cubeEntity.isDoubleJumping = true;
                }
            }
        }
    }
}
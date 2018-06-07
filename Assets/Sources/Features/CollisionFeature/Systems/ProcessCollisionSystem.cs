using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class ProcessCollisionSystem : ReactiveSystem<GameEntity>
    {
        private IContext<GameEntity> _context;

        public ProcessCollisionSystem(IContext<GameEntity> context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collision);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var cubeEntity in entities)
            {
                Debug.Log(cubeEntity.collision.other.name);
                if (cubeEntity.collision.other.CompareTag(GameConfig.ObstacleTag))
                {
                    var endGameEntity = _context.CreateEntity().isEndGame = true;
                }
                else if (cubeEntity.collision.other.CompareTag(GameConfig.PlatformTag))
                {
                    cubeEntity.isJumping = false;
                    cubeEntity.isDoubleJumping = false;
//                    cubeEntity.ReplaceVelocity(new Vector3(cubeEntity.velocity.value.x, 0f, cubeEntity.velocity.value.z));
                    cubeEntity.ReplacePosition(new Vector3(cubeEntity.position.value.x, cubeEntity.collision.other.transform.position.y + 1f, cubeEntity.position.value.z));
                }
                cubeEntity.RemoveCollision();
            }
        }
    }
}
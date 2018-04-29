using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class ProcessCollisionSystem : ReactiveSystem<GameEntity>
    {
        public ProcessCollisionSystem(IContext<GameEntity> context) : base(context)
        {
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
            foreach (var gameEntity in entities)
            {
                Debug.Log(gameEntity.collision.other.name);
                gameEntity.RemoveCollision();
            }
        }
    }
}
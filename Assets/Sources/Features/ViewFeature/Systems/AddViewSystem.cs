using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class AddViewSystem : ReactiveSystem<GameEntity>
    {
        private IContext<GameEntity> _context;
        private Transform _gameContainer;

        public AddViewSystem(IContext<GameEntity> context) : base(context)
        {
            _context = context;
            _gameContainer = new GameObject("GameContainer").transform;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Prefab);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.AddView(Object.Instantiate(Resources.Load<GameObject>(gameEntity.prefab.value)));
                gameEntity.view.value.transform.SetParent(_gameContainer);
            }
        }
    }
}
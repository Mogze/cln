using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

namespace cln
{
    public sealed class EndSystem : ReactiveSystem<GameEntity>
    {
        private IContext<GameEntity> _context;

        public EndSystem(IContext<GameEntity> context) : base(context)
        {
            _context = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.EndGame);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.isEndGame = false;
                foreach (var entity in _context.GetEntities())
                {
                    if (entity.hasView && entity.view.value.GetComponent<EntityLink>() != null)
                        entity.view.value.GetComponent<EntityLink>().Unlink();

                    entity.Destroy();
                }

                MenuManager.Instance.Close(typeof(GameMenu));
                MenuManager.Instance.Show(typeof(MainMenu));
                Main.Instance.EndGame();
            }
        }
    }
}
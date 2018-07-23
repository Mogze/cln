using System.Collections.Generic;
using cln.Sources.Utilities;
using Entitas;
using UnityEngine;

namespace cln
{
    public class ScoreSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameEntity _highScoreEntity;
        
        public ScoreSystem(IContext<GameEntity> context) : base(context)
        {
            _highScoreEntity = context.CreateEntity();
            _highScoreEntity.AddHighScore(PlayerPrefs.GetInt(GameConsts.Persistence.HighScoreKey));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameScore);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var scoreEntity = entities.SingleEntity();
            if (scoreEntity.gameScore.value > _highScoreEntity.highScore.value)
            {
                _highScoreEntity.ReplaceHighScore(scoreEntity.gameScore.value);
                PlayerPrefs.SetInt(GameConsts.Persistence.HighScoreKey, _highScoreEntity.highScore.value);
            }
        }
    }
}
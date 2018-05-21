using Entitas;
using UnityEngine;

namespace cln
{
    public class GenerateObstacleSystem : IExecuteSystem
    {
        private IContext<GameEntity> _context;
        private const float TimerStart = 5f;
        private float _timer = TimerStart;

        public GenerateObstacleSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Execute()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                _timer += TimerStart;

                var obstacleEntity = _context.CreateEntity();
                obstacleEntity.AddPrefab("Prefabs/Game/Obstacle");
                obstacleEntity.AddPosition(new Vector3(20f, -9f, 0f));
                obstacleEntity.isObstacle = true;
            }
        }
    }
}
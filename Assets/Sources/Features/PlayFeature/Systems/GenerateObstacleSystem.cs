using Entitas;
using UnityEngine;

namespace cln
{
    public class GenerateObstacleSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IContext<GameEntity> _context;
        private const float TimerStart = 1f;
        private float _timer = TimerStart;
        private GameEntity _cubeEntity;
        private int _obstacleIndex = 0;

        public GenerateObstacleSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _cubeEntity = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();

            for (; _obstacleIndex < 2; _obstacleIndex++)
            {
                var obstacleEntity = _context.CreateEntity();
                obstacleEntity.AddPrefab("Prefabs/Game/Platform");
                obstacleEntity.AddPosition(new Vector3(_obstacleIndex * 20f, -10f, 0f));
                obstacleEntity.isObstacle = true;
            }
        }

        public void Execute()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                _timer += TimerStart;

                var obstacleEntity = _context.CreateEntity();
                obstacleEntity.AddPrefab(Random.Range(0, 2) == 0 ? "Prefabs/Game/Obstacle" : "Prefabs/Game/Obstacle 1");
                obstacleEntity.AddPosition(new Vector3(_obstacleIndex * 20f, -10f, 0f));
                obstacleEntity.isObstacle = true;
                _obstacleIndex++;
            }
        }
    }
}
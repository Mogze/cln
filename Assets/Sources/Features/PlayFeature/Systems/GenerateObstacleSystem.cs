using Entitas;
using UnityEngine;

namespace cln
{
    public class GenerateObstacleSystem : IInitializeSystem, IExecuteSystem
    {
        private IContext<GameEntity> _context;
        private const float TimerStart = 5f;
        private float _timer = TimerStart;
        private GameEntity _cubeEntity;

        public GenerateObstacleSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _cubeEntity = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
        }

        public void Execute()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                _timer += TimerStart;

                var obstacleEntity = _context.CreateEntity();
                obstacleEntity.AddPrefab("Prefabs/Game/Obstacle");
                obstacleEntity.AddPosition(new Vector3(_cubeEntity.position.value.x + 20f, -9f, 0f));
                obstacleEntity.isObstacle = true;
            }
        }
    }
}
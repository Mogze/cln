﻿using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class GenerateObstacleSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IContext<GameEntity> _context;
        private const float TimerStart = 1f;
        private float _timer = TimerStart;
        private GameEntity _cubeEntity;
        private int _obstacleIndex = 0;
        private int _prevHeight = -35;

        private readonly string[] obstacles =
        {
            "Obstacle",
            "Obstacle 1",
            "Obstacle 2",
            "Obstacle 3",
            "Obstacle 4",
            "Obstacle 5",
            "Obstacle 6"
        };

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
                obstacleEntity.AddPosition(new Vector3(_obstacleIndex * 20f, _prevHeight, 0f));
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
                obstacleEntity.AddPrefab("Prefabs/Game/" + obstacles[Random.Range(0, obstacles.Length)]);
                var newHeight = _prevHeight + Random.Range(-5, 6);
                obstacleEntity.AddPosition(new Vector3(_obstacleIndex * 20f, newHeight, 0f));
                _prevHeight = newHeight;
                obstacleEntity.isObstacle = true;
                _obstacleIndex++;
            }
        }
    }
}
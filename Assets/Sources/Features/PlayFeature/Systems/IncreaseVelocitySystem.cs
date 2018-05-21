using Entitas;
using UnityEngine;
using zehreken.i_cheat;

namespace cln
{
    public sealed class IncreaseVelocitySystem : IInitializeSystem, IExecuteSystem
    {
        private IContext<GameEntity> _context;
        private GameEntity _cube;
        private float _timer = 0f;

        public IncreaseVelocitySystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _cube = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
            _timer = GameConfig.CubeVelocityStepTimer;
        }
        
        public void Execute()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _cube.ReplaceVelocity(_cube.velocity.value + GameConfig.CubeVelocityStep);
                _timer += GameConfig.CubeVelocityStepTimer;
            }
        }
    }
}
using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class StartSystem : IInitializeSystem
    {
        private readonly IContext<GameEntity> _context;

        public StartSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            Debug.Log("Initialize");

            var cubeEntity = _context.CreateEntity();
            cubeEntity.AddPrefab("Prefabs/Game/Cube");
            cubeEntity.AddPosition(new Vector3(-8f, -0f, 0f));
            cubeEntity.AddVelocity(GameConfig.CubeMoveVelocity);
            cubeEntity.isCube = true;
        }
    }
}
using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class StartSystem : IInitializeSystem
    {
        private IContext<GameEntity> _context;

        public StartSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            Debug.Log("Initialize");

            var platformEntity = _context.CreateEntity();
            platformEntity.AddPrefab("Prefabs/Game/Platform");
            platformEntity.AddPosition(Vector3.down * 10f);

            var cubeEntity = _context.CreateEntity();
            cubeEntity.AddPrefab("Prefabs/Game/Cube");
            cubeEntity.AddPosition(new Vector3(-8f, -9f, 0f));
            cubeEntity.isCube = true;
        }
    }
}
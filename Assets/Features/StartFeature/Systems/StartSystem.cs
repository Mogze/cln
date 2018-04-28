using Entitas;
using UnityEngine;

namespace cln
{
    public class StartSystem : IInitializeSystem
    {
        private IContext<GameEntity> _context;
        
        public StartSystem(IContext<GameEntity> context)
        {
            _context = context;
        }
        
        public void Initialize()
        {
            Debug.Log("Initialize");
            
            var gameEntity = _context.CreateEntity();
            gameEntity.AddPrefab("Prefabs/Game/Platform");
            gameEntity.AddPosition(Vector3.down * 10f);
        }
    }
}
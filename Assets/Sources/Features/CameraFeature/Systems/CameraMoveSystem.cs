using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class CameraMoveSystem : IExecuteSystem
    {
        private IContext<GameEntity> _context;
        private readonly Transform _cameraTransform;
        private GameEntity _cubeEntity;

        public CameraMoveSystem(IContext<GameEntity> context)
        {
            _context = context;
            _cameraTransform = Camera.main.transform;
            _cubeEntity = context.GetGroup(GameMatcher.Cube).GetSingleEntity();
        }

        public void Execute()
        {
            if (_cubeEntity == null)
                _cubeEntity = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
            _cameraTransform.position = new Vector3(_cubeEntity.position.value.x + 8f, _cubeEntity.position.value.y + 9f, -10f);
        }
    }
}
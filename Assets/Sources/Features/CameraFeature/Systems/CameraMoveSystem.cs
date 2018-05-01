using Entitas;
using UnityEngine;

namespace cln
{
    public sealed class CameraMoveSystem : IInitializeSystem, IExecuteSystem
    {
        private IContext<GameEntity> _context;
        private Transform _cameraTransform;
        private GameEntity _cubeEntity;

        public CameraMoveSystem(IContext<GameEntity> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _cameraTransform = Camera.main.transform;
            _cubeEntity = _context.GetGroup(GameMatcher.Cube).GetSingleEntity();
        }

        public void Execute()
        {
            var diff = new Vector3(_cubeEntity.position.value.x + 8f, _cubeEntity.position.value.y + 9f, -10f) - _cameraTransform.position;
            _cameraTransform.Translate(diff * 2f * Time.deltaTime);
        }
    }
}
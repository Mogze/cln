using Entitas;

namespace cln
{
    public class GenerateObstacleSystem : IExecuteSystem
    {
        private IContext<GameEntity> _context;

        public GenerateObstacleSystem(IContext<GameEntity> context)
        {
            _context = context;
        }
        public void Execute()
        {
        }
    }
}
using Entitas;

namespace cln
{
    public class GameController
    {
        private Systems _systems;
        
        public GameController()
        {
            _systems = new GameSystems(Contexts.sharedInstance);
            _systems.Initialize();
        }

        public void Update(float deltaTime)
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        ~GameController()
        {
            _systems.ClearReactiveSystems();
            _systems.TearDown();
        }
    }
}
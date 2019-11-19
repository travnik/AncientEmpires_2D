using Zenject;

namespace Travnik.AncientEmpires
{
    public class CustomMapCellFactory : IFactory<MapCell>
    {
        private readonly DiContainer _container;

        public CustomMapCellFactory(DiContainer container)
        {
            _container = container;
        }

        public MapCell Create()
        {
            return _container.InstantiateComponentOnNewGameObject<MapCell>(); 
        }
    }
}

using Zenject;
using NUnit.Framework;
using Travnik.AncientEmpires;
using UnityEditor.SceneManagement;
using UnityEngine;

[TestFixture]
public class MapProviderTests : ZenjectUnitTestFixture
{
    [SetUp]
    public override void Setup()
    {
        base.Setup();
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

        Container.Bind<IMapProvider>().To<MapProvider>().AsSingle();
        Container.Bind<IGeometry>().To<Geometry2D>().AsSingle();
        Container.Bind<MapCell>().FromInstance(new MapCell()).AsTransient();
        Container.BindFactory<MapCellType, MapCell, MapCellFactory>().FromMethod(CreateMapCell);
    }

    private MapCell CreateMapCell(DiContainer _, MapCellType type)
    {
        return Container.InstantiateComponentOnNewGameObject<MapCell>();
    }

    [Test]
    public void Load()
    {
        var mapProvider = Container.Resolve<IMapProvider>();
        mapProvider.Load();
        var cell = mapProvider.Get(4, 2);
        Assert.NotNull(cell);
        Assert.True(4 == cell.ArrayPosition.x);
        Assert.True(2 == cell.ArrayPosition.y);
    }
}
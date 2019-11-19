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

        Container.Bind<MapProvider>().To<MapProvider>().AsSingle();
        Container.Bind<MapCell>().FromInstance(new MapCell()).AsTransient();
        Container.BindFactory<MapCell, MapCellFactory>().FromFactory<CustomMapCellFactory>();
    }
    [Test]
    public void Load()
    {
        var mapProvider = Container.Resolve<MapProvider>();
        mapProvider.Load();
        var cell = mapProvider.Get(4, 2);
        Assert.NotNull(cell);
        Assert.True(4 == cell.ArrayPosition.x);
        Assert.True(2 == cell.ArrayPosition.y);
    }
}
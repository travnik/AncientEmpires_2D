using System.Linq;
using Moq;
using Zenject;
using NUnit.Framework;
using Travnik.AncientEmpires;
using UnityEditor.SceneManagement;
using UnityEngine;

[TestFixture]
public class Raycast2DSelectorsTests : ZenjectUnitTestFixture
{
    [SetUp]
    public override void Setup()
    {
        base.Setup();
        EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
        var camera = Object.FindObjectOfType<Camera>();
        Container.Bind<Camera>().FromInstance(camera).AsSingle();
        Container.Bind<IGeometry>().To<Geometry2D>().AsSingle();
    }

    [Test]
    public void Select_NotFoundObject()
    {
        var stubMapProvider = new Mock<IMapProvider>();
        stubMapProvider.Setup(i => i.IsValid(It.IsAny<int>(), It.IsAny<int>())).Returns(() => false);
        var stubUnitProvider = new Mock<IUnitProvider>();
        stubUnitProvider.Setup(i => i.Get(It.IsAny<Vector2Int>())).Returns(() => null);
        Container.Bind<IMapProvider>().FromInstance(stubMapProvider.Object).AsSingle();
        Container.Bind<IUnitProvider>().FromInstance(stubUnitProvider.Object).AsSingle();

        var objectSelector = Container.Instantiate<ObjectSelector>();
        var position = new Vector3(0, 0, 0);
        var result = objectSelector.Select(position);
        Assert.Null(result.MapCell);
    }


    [Test]
    public void Select_FoundObject()
    {
        var geometry = new Geometry2D();
        var mapcell = Container.InstantiateComponentOnNewGameObject<MapCell>();
        var stubMapProvider = new Mock<IMapProvider>();
        stubMapProvider.Setup(i => i.Get(It.IsAny<int>(), It.IsAny<int>())).Returns(() => mapcell);
        stubMapProvider.Setup(i => i.IsValid(It.IsAny<int>(), It.IsAny<int>())).Returns(() => true);
        Container.Bind<IMapProvider>().FromInstance(stubMapProvider.Object).AsSingle();
        var stubUnitProvider = new Mock<IUnitProvider>();
        stubUnitProvider.Setup(i => i.Get(It.IsAny<Vector2Int>())).Returns(() => null);
        Container.Bind<IUnitProvider>().FromInstance(stubUnitProvider.Object).AsSingle();

        var camera = Object.FindObjectOfType<Camera>();
        var worldToScreenPoint = camera.WorldToScreenPoint(geometry.PointFromGrid(0, 0));

        var objectSelector = Container.Instantiate<ObjectSelector>();

        var result = objectSelector.Select(worldToScreenPoint);
        Assert.NotNull(result.MapCell);
    }
}
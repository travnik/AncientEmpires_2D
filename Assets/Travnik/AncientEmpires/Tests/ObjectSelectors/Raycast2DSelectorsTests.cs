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
    }

    [Test]
    public void Select_NotFoundObject()
    {
        var objectSelector = Container.Instantiate<Raycast2DSelector>();
        var position = new Vector3(0, 0, 0);
        var result = objectSelector.Select(position);
        Assert.Null(result);
    }


    [Test]
    public void Select_FoundObject()
    {
        var gameObject = new GameObject("test").AddComponent<BoxCollider>();

        var camera = Object.FindObjectOfType<Camera>();
        var worldToScreenPoint = camera.WorldToScreenPoint(gameObject.transform.position);

        var objectSelector = Container.Instantiate<Raycast2DSelector>();

        var result = objectSelector.Select(worldToScreenPoint);
        Assert.NotNull(result);
    }
}
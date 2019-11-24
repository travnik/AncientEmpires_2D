using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
using Travnik.AncientEmpires;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;

namespace Tests
{
    public class Raycast2DSelectorGameModeTests : ZenjectUnitTestFixture
    {
        private Scene _scene;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            SceneManager.LoadScene("SampleScene");
            _scene = SceneManager.GetSceneByName("SampleScene");
            //_scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
            var obj = _scene.GetRootGameObjects();
            //obj.First().
            var camera = Object.FindObjectOfType<Camera>();
            Container.Bind<Camera>().FromInstance(camera).AsSingle();
            //Container.Bind<CursorObjectSelector>().FromNewComponentOnNewGameObject().AsSingle();
        }

        [Test]
        public void Select_FoundObject()
        {
            var objectSelector = Container.Instantiate<ObjectSelector>();
            var position = new Vector3(530, 276, 0);

            //var gameObject = Container.Instantiate<GameObject>();
            //var gameObject = new GameObject("test").AddComponent<BoxCollider>();
            //gameObject.transform.position = position;
            //Container.BindInstance(gameObject);

            //var Container.Instantiate<GameObject>();..FromInstance(new GameObject("Main Camera").AddComponent<Camera>()).AsSingle();
            //_scene.GetRootGameObjects()
            //gameObject..scene = _scene;
            //var select = Container.Instantiate<GameObject>(); //GameObject.Instantiate(new GameObject());
            var result = objectSelector.Select(position);
            Assert.NotNull(result);
        }
    }
}
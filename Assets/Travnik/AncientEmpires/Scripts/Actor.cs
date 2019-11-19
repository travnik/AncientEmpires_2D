using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class Actor : MonoBehaviour
    {
        private Player _player;

        [Inject]
        public void Constructor(Player player)
        {
            _player = player;
        }

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("player=" + _player);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
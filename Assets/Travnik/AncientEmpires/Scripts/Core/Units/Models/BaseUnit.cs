using UnityEngine;

namespace Travnik.AncientEmpires
{
    public class BaseUnit : MonoBehaviour, IBaseUnit
    {
        public PlayerTeam PlayerTeam { get; set; }

        private SpriteRenderer _spriteRenderer;
        public Vector2Int ArrayPosition { get; set; }
        public Vector3 WorldPosition => transform.position;
        public int MovePoint { get; protected set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public Sprite GetIcon()
        {
            return _spriteRenderer.sprite;
        }
    }
}

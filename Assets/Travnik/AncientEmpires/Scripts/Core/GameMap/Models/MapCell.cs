using UnityEngine;

namespace Travnik.AncientEmpires
{
    public class MapCell : MonoBehaviour, IMapCell
    {
        private SpriteRenderer _spriteRenderer;
        public MapCellInfo MapCellInfo{ get; set; }
        public Vector2Int ArrayPosition { get; set; }
        public Vector3 WorldPosition => transform.position;

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

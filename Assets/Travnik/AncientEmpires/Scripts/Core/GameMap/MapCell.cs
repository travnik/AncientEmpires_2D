using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IMapCell
    {
        MapCellInfo MapCellInfo { get; }
        Vector2Int ArrayPosition { get; }
        Vector3 WorldPosition { get; }
        Sprite GetIcon();
    }

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

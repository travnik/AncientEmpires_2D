using UnityEngine;

namespace Travnik.AncientEmpires
{
    public interface IBaseUnit
    {
        Vector2Int ArrayPosition { get; }
        Vector3 WorldPosition { get; }
        Sprite GetIcon();
    }

    public class BaseUnit : MonoBehaviour, IBaseUnit
    {
        private SpriteRenderer _spriteRenderer;
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

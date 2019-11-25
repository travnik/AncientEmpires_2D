using System;
using UnityEngine;
using UnityEngine.UI;

namespace Travnik.AncientEmpires
{
    public class IconPanelPresentor : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _defenseText;

        public void Present(IMapCell mapCell)
        {
            _iconImage.sprite = mapCell.GetIcon();
            _nameText.text = mapCell.MapCellInfo.Name;
            _defenseText.text = mapCell.MapCellInfo.Defense.ToString();
        }

        public void Present(Sprite sprite, String name)
        {
            _iconImage.sprite = sprite;
            _nameText.text = name;
            _defenseText.text = null;
        }

        public void Clear()
        {
            _iconImage.sprite = null;
            _nameText.text = null;
            _defenseText.text = null;
        }
    }
}

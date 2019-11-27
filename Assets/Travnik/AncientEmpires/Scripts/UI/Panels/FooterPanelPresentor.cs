using System;
using UnityEngine;
using UnityEngine.UI;

namespace Travnik.AncientEmpires
{
    public class FooterPanelPresentor : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Text _defenseText;

        public void Present(IMapCell mapCell)
        {
            _iconImage.sprite = mapCell.GetIcon();
            _defenseText.text = mapCell.MapCellInfo.Defense.ToString();
        }

        public void Clear()
        {
            _iconImage.sprite = null;
            _defenseText.text = null;
        }
    }
}

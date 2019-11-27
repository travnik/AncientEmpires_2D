using UnityEngine;
using UnityEngine.UI;

namespace Travnik.AncientEmpires
{
    public class HeaderPanelPresentor : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void Present(IBaseUnit unit)
        {
            //TODO
            if (unit != null)
            {
                _image.sprite = unit.GetIcon();
            }
            else
            {
                Clear();
            }
        }

        public void Clear()
        {
            _image.sprite = null;
        }
    }
}

using UnityEngine;
using Zenject;

namespace Travnik.AncientEmpires
{
    public class CursorController : MonoBehaviour
    {
        private IObjectSelector _selector;
        private ISelect _currentSelect;
        private IconPanelPresentor _iconPanelPresentor;
        private CursorPresentor _cursorPresentor;

        [Inject]
        public void Constructor(IObjectSelector selector, IconPanelPresentor iconPanelPresentor,
            CursorPresentor cursorPresentor)
        {
            _selector = selector;
            _iconPanelPresentor = iconPanelPresentor;
            _cursorPresentor = cursorPresentor;
        }

        private void Update()
        {
            var pos = Input.mousePosition;
            Debug.Log("mouse pos " + pos);
            _currentSelect = _selector.Select(pos);
            Debug.Log("result=" + _currentSelect.MapCell);
            Show();
        }

        private void Show()
        {
            if (_currentSelect?.MapCell != null)
            {
                _cursorPresentor.Show(_currentSelect.MapCell.WorldPosition);
                _iconPanelPresentor.Present(_currentSelect.MapCell);
            }
            else
            {
                _cursorPresentor.Hide();
                _iconPanelPresentor.Clear();
            }
        }
    }
}

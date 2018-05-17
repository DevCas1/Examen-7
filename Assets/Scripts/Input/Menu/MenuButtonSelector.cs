using UnityEngine;
using Sjouke.CodeArchitecture.Button;

public sealed class MenuButtonSelector : MonoBehaviour
{
    public LayerMask UILayer;
    public float RaycastDistance = 30;

    private RaycastHit _hit;
    private MenuButton _button;

    private void FixedUpdate() => CheckForMenuButton();

    private void CheckForMenuButton()
    {
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, RaycastDistance, UILayer))
        {
            if (_button != null)
                _button.OnButtonLeave();
            _button = null;
            return;
        }

        if (_button && _hit.transform) return;
        
        if (_hit.transform == _button?.transform) return;

        var tempButton = _hit.transform.GetComponent<MenuButton>();

        if (tempButton != _button)
            _button?.OnButtonLeave();

        _button = tempButton;
        _button.OnButtonHover();
    }

    public void OnMouseClick()
    {
        if (_button == null) return;
        _button.OnButtonPressed();
    }
}
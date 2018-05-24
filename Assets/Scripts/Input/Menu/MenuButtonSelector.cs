using UnityEngine;
using Sjouke.CodeArchitecture.Button;

public sealed class MenuButtonSelector : MonoBehaviour
{
    public LayerMask UILayer;
    public float RaycastDistance = 30;

    private RaycastHit _hit;
    private MenuButton _button;

    private void Update() => CheckForMenuButton();

    private void CheckForMenuButton()
    {
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, RaycastDistance, UILayer))
        {
            if (_button != null)
                _button.OnButtonLeave();
            _button = null;
            return;
        }

        if (_button == null && _hit.transform == null) return;
        
        if (_button != null && _hit.transform == _button.transform) return;

        MenuButton tempButton = _hit.transform.GetComponent<MenuButton>();
        
        if (tempButton != _button && _button != null)
            _button.OnButtonLeave();

        if (tempButton == null) return;

        _button = tempButton;
        _button.OnButtonHover();
    }

    public void OnMouseClick()
    {
        if (_button == null) return;
        _button.OnButtonPressed();
    }

    public void OnMouseRelease()
    {
        if (_button == null) return;
        _button.OnButtonReleased();
    }
}
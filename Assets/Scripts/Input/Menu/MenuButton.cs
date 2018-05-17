namespace Sjouke.CodeArchitecture.Button
{
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent(typeof(BoxCollider))]
    public sealed class MenuButton : MonoBehaviour
    {
        public UnityEvent OnMouseOver;
        public UnityEvent OnMouseDown;
        public UnityEvent OnMouseExit;

        public void OnButtonHover() => OnMouseOver.Invoke();

        public void OnButtonLeave() => OnMouseExit.Invoke();

        public void OnButtonPressed() => OnMouseDown.Invoke();
    }
}
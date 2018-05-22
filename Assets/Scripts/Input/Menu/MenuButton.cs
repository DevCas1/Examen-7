namespace Sjouke.CodeArchitecture.Button
{
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent(typeof(BoxCollider))]
    public sealed class MenuButton : MonoBehaviour
    {
        public UnityEvent OnMouseOver;
        public UnityEvent OnMouseDown;
        public UnityEvent OnMouseUp;
        public UnityEvent OnMouseExit;

        public void OnButtonHover() => OnMouseOver.Invoke();

        public void OnButtonLeave() => OnMouseExit.Invoke();

        public void OnButtonPressed() => OnMouseDown.Invoke();

        public void OnButtonReleased() => OnMouseUp.Invoke();

        private void OnDisable() => OnButtonLeave();
    }
}
namespace Sjouke.Input
{
    using UnityEngine;

    public sealed class MouseCursor : MonoBehaviour
    {
        public GameObject CursorPrefab;
        private GameObject _cursor;
        private Vector3 _mousePos;

        private void Awake()
        {
            if (_cursor == null)
                _cursor = Instantiate(CursorPrefab, transform.position, Quaternion.identity, this.transform);
        }

        private void Update()
        {
            if (Cursor.visible) Cursor.visible = false;
             _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            transform.position = _mousePos;
        }
    }
}
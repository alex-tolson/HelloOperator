using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _mousePosition;
    [SerializeField] private Texture2D _cursorTexture;
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotspot = Vector2.zero;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(_cursorTexture, _hotspot, _cursorMode);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null , _hotspot, _cursorMode);
    }

    private void OnMouseDown()
    {
        _mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }
}

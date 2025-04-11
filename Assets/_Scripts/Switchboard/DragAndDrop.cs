using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _mousePosition;
    [SerializeField] private Texture2D _cursorPoint;
    [SerializeField] private Texture2D _cursorGrab;
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 _hotspot = Vector2.zero;
    [SerializeField] private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if(_audioManager == null)
        {
            Debug.LogError("DragAndDrop::AudioManager is null");
        }
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(_cursorPoint, _hotspot, _cursorMode);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null , _hotspot, _cursorMode);
        //_audioManager.PlayRandomPlugin();
    }

    private void OnMouseDown()
    {
        Cursor.SetCursor(_cursorGrab, _hotspot, _cursorMode);
        _mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }

    private void OnMouseUp()
    {
        Cursor.SetCursor(_cursorPoint, _hotspot, _cursorMode);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchboardLights : MonoBehaviour, IPointerClickHandler
{
    private IncomingWire _incomingWire;
    private Color _color;

    private void Start()
    {
        _incomingWire = FindObjectOfType<IncomingWire>(true); //finds incoming wire even if it's inactive
        if (_incomingWire == null)
        {
            Debug.LogError("SwitchboardLights::Wires function is null");
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        _incomingWire.gameObject.SetActive(true);
        //_incomingWire.ConnectWireAtAnchor(this);
    }

    public void TurnLightColor(Color color)
    {
        gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().color = color;
    }

    public float FindNearestLight(Vector3 position)
    {
        var distance = Vector3.Distance(transform.position, position);
        return distance;
    }

    public void TurnOffLight()
    {
        gameObject.SetActive(false);
    }
}

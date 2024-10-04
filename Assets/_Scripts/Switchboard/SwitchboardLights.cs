using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchboardLights : MonoBehaviour, IPointerClickHandler
{
    private IncomingWire _incomingWire;
    //private PointerEventData _wireData;

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
        _incomingWire.ConnectWireAtAnchor(transform.position);
    }


    public void TurnOnLight()
    { 
        gameObject.SetActive(true);
    }
}

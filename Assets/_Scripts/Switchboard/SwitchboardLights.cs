using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchboardLights : MonoBehaviour, IPointerClickHandler
{

    private WiresFunction _wiresFunction;
    //private PointerEventData _wireData;
    private void Start()
    {
        _wiresFunction = FindObjectOfType<WiresFunction>(true);
        if (_wiresFunction == null)
        {
            Debug.LogError("SwitchboardLights::Wires function is null");
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Connect wire");
        gameObject.SetActive(false);
        _wiresFunction.gameObject.SetActive(true);
        _wiresFunction.ConnectWireAtAnchor();
    }


    public void TurnOnLight()
    { 
        gameObject.SetActive(true);
    }
}

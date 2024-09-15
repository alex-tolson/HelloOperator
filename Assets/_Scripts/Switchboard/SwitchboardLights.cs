using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchboardLights : MonoBehaviour, IPointerClickHandler
{

    private WiresFunction _wiresFuntion;
    //private PointerEventData _wireData;
    private void Start()
    {
        _wiresFuntion = FindObjectOfType<WiresFunction>(true);
        if (_wiresFuntion == null)
        {
            Debug.LogError("SwitchboardLights::Wires function is null");
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Connect wire");
        gameObject.SetActive(false);
        _wiresFuntion.ActivateWire();
    }


    public void TurnOnLight()
    { 
        gameObject.SetActive(true);
    }
}

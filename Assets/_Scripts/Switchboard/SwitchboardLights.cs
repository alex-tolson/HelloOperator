using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchboardLights : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }

    public void TurnOnLight()
    { 
        gameObject.SetActive(true);
    }
}

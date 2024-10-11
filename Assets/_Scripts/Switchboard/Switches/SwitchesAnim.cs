using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchesAnim : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private SpriteRenderer _mainToggle;
    [SerializeField] private Sprite _toggleUp;
    [SerializeField] private Sprite _toggleDown;
    int i = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == _mainToggle.name)
        {
            OnToggleClicked();
            //if outgoing
            //OutgoingJack _jack,
            //AnchorPlaceHolder _switchboardPosition
            //and SwitchboardLights _light are not null
            //then we know we have the connection
            //turn the lights blue.
        }
    }

    

    public void OnToggleClicked()
    {
        ++i;

        if (i == 1)
        {
            _mainToggle.sprite = _toggleUp;

        }
        else if (i == 2)
        {
            _mainToggle.sprite = _toggleDown;
            i = 0;
        }
    }    
}

using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchesAnim : MonoBehaviour , IPointerClickHandler
{
    //when switch is pressed
    //toggle up
    //when switch is pressed again
    //toggle down
    //if pressed a third time
    //toggle off

    [SerializeField] private SpriteRenderer _mainToggle;
    [SerializeField] private Sprite _toggleUp;
    [SerializeField] private Sprite _toggleDown;
    int i = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == _mainToggle.name)
        {
            OnToggleClicked();
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

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchesAnim : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private SpriteRenderer _mainToggle;
    [SerializeField] private Sprite _toggleUp;
    [SerializeField] private Sprite _toggleDown;
    private Switch _currentSwitch;
    private int i = 0;

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
            _currentSwitch = Switch.ToggleUp;

            //initiated convo with operator.  do not continue until finished or skipped to finish
            //if this switch is flipped
            //the corrresponding light will turn green
            //dialogue will play/appear
            //switch cannot be flipped until dialogue is complete or skipped.

        }
        else if (i == 2)
        {
            _mainToggle.sprite = _toggleDown;
            _currentSwitch = Switch.ToggleDown;
            //turn off the light attached to the switches
            i = 0;
            //terminate call
        }
    }

    public Switch ToggleStatus()
    {
        if (_currentSwitch == Switch.ToggleUp)
        {
            return Switch.ToggleUp;
        }
        else
        {
            return Switch.ToggleDown;
        }
    }
}

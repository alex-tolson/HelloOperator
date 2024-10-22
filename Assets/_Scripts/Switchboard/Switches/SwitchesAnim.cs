using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchesAnim : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private SpriteRenderer _mainToggle;
    [SerializeField] private Sprite _toggleUp;
    [SerializeField] private Sprite _toggleDown;
    private LightsSlot[] _lightsSlots;
    private Switch _currentSwitch;
    private int i = 0;

    private void Start()
    {
        _lightsSlots = FindObjectsOfType<LightsSlot>(true);
        if (_lightsSlots.Length == 0)
        {
            Debug.LogError("SwitchesAnim::LightsSlot array is empty");
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == _mainToggle.name)
        {
            foreach (LightsSlot light in _lightsSlots)
            {
                if (light.name == this.name)
                {
                    OnToggleClicked();
                    light.Toggle(this);         
                }
            }
        }
    }

    public void OnToggleClicked()
    {
        ++i;

        if (i == 1)
        {
            _mainToggle.sprite = _toggleUp;
            _currentSwitch = Switch.ToggleUp;

            //the corrresponding light will turn green
            //dialogue will play/appear
            //switch cannot be flipped until dialogue is complete or skipped.

        }
        else if (i == 2)
        {
            _mainToggle.sprite = _toggleDown;
            _currentSwitch = Switch.ToggleDown;
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

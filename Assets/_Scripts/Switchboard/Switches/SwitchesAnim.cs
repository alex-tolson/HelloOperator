using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchesAnim : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private SpriteRenderer _mainToggle;
    [SerializeField] private Sprite _toggleUp;
    [SerializeField] private Sprite _toggleDown;
    private LightsSlot[] _lightsSlots;
    private Switch _currentSwitch;
    private Switchboard2 _switchboard2;
    private DialogueManager _dialogueManager;
    private CallManager _callManager;
    private int i = 0;

    private GameObject _outgoingWireGO;
    private GameObject _incomingWireGO;

    private void Start()
    {
        _callManager = GameObject.Find("Switchboard").GetComponent<CallManager>();
        if(_callManager == null)
        {
            Debug.LogError("SwitchesAnim::CallManager is null");
        }
        _dialogueManager = GameObject.Find("Canvas_WorldSpace").GetComponent<DialogueManager>();
        if(_dialogueManager == null)
        {
            Debug.LogError("SwitchesAnim::Dialogue Manager is null");
        }
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("SwitchesAnim::Switchboard2 is null");
        }
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
            OnToggleClicked();

            foreach (LightsSlot light in _lightsSlots)
            {

                if (light.name == this.name)
                {
                    light.Toggle(this);
                }
            }

            if (_currentSwitch == Switch.ToggleUp)
            {
                if (_switchboard2.WhoIsCalling() != null)
                {
                    _dialogueManager.CycleThroughDialogue();

                    //if toggle is up
                    //if switchboard2 incoming call is connected
                    //activate dialogue
                }
                if (_switchboard2.WhoIsAnswering() != null)
                {
                    _callManager.ContinueConvoCaller();
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
            //display diaglog and lock toggle in place
            //if toggle is up and the call is initialized
            //dialogue will play/appear
            //switch cannot be flipped until dialogue is complete or skipped.

        }
        else if (i == 2)
        {
            _mainToggle.sprite = _toggleDown;
            _currentSwitch = Switch.ToggleDown;
            i = 0;
            _incomingWireGO = GameObject.Find("Wire-Incoming(Clone)");
            _outgoingWireGO = GameObject.Find("OutgoingWire(Clone)");
            //terminate call
            //terminate incoming and outgoing wires
  
            if (_switchboard2.IsCallCompleted() && _incomingWireGO != null)
            {
                _outgoingWireGO.GetComponent<OutgoingWire>().DisconnectWire();
                _incomingWireGO.GetComponent<IncomingWire>().DisconnectWire();
            }
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

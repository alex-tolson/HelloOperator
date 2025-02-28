using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchesAnim : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer _mainToggle;
    [SerializeField] private Sprite _toggleUp;
    [SerializeField] private Sprite _toggleDown;
    [SerializeField] private IncomingWire _incomingWire;
    [SerializeField] private IncomingJack _jack;
    [SerializeField] private SwitchboardSO _incomingCall;
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
        if (_callManager == null)
        {
            Debug.LogError("SwitchesAnim::CallManager is null");
        }
        _dialogueManager = GameObject.Find("Canvas_WorldSpace").GetComponent<DialogueManager>();
        if (_dialogueManager == null)
        {
            Debug.LogError("SwitchesAnim::Dialogue Manager is null");
        }
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("SwitchesAnim::Switchboard2 is null");
        }
        _lightsSlots = GameObject.Find("SwitchboardLights").GetComponentsInChildren<LightsSlot>();
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

                    if (_currentSwitch == Switch.ToggleUp)
                    {

                        if (_switchboard2.WhoIsCalling() != null &&
                            _switchboard2.WhoIsCalling().name == this.gameObject.name)
                        {
                            Debug.Log("starting dialog");
                            _dialogueManager.CycleThroughDialogue();


                            //lock toggle into up position till convo is done
                        }
                        if (_switchboard2.WhoIsAnswering() != null && _switchboard2.WhoIsAnswering().name == this.gameObject.name)
                        {
                            _callManager.ContinueConvoCaller();
                        }
                    }
                    else if (_currentSwitch == Switch.ToggleDown)
                    {
                        light.DisconnectWires();
                    }
                }
            }
        }
    }


    public String WhichSwitchFlipped()
    {
        return this.gameObject.name;
    }

    public void OnToggleClicked()
    {
        ++i;

        if (i == 1)
        {
            _mainToggle.sprite = _toggleUp;
            _currentSwitch = Switch.ToggleUp;
            _incomingWire = FindObjectOfType<IncomingWire>(true); //finds incoming wire even if it's inactive
            if (_incomingWire == null)
            {
                //have popup saying "no answer" or "no one is on the line" and dial tone sound fx playing
            }
            else
            {
                _switchboard2.IncomingCall();
            }
        }
        else if (i == 2)
        {
            _mainToggle.sprite = _toggleDown;
            _currentSwitch = Switch.ToggleDown;
            i = 0;
            _incomingWireGO = GameObject.Find("Wire-Incoming(Clone)");
            _outgoingWireGO = GameObject.Find("OutgoingWire(Clone)");
  
            if (_switchboard2.IsCallCompleted() && _incomingWireGO != null)
            {
                _switchboard2.ClearComingAndGoing();

            }
            _switchboard2.StateMachineIdle();
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

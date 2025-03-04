using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchesAnim : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer _mainToggle;
    [SerializeField] private Sprite _toggleUp;
    [SerializeField] private Sprite _toggleDown;
    private IncomingWire _incomingWireGO;
    private OutgoingWire _outgoingWireGO;
    private GameObject _outgoingWire;
    [SerializeField] private SwitchboardSO _incomingCall;
    [SerializeField] private SwitchboardSO _outgoingCallee;
    private LightsSlot[] _lightsSlots;
    private Switch _currentSwitch;
    private Switchboard2 _switchboard2;

    private int i = 0;
    [SerializeField] private LightsSlot _slot;
    [SerializeField] private GameObject _outgoingWirePrefab;
    [SerializeField] private GameObject _incomingWirePrefab;

    private void Start()
    {
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

            foreach (LightsSlot slot in _lightsSlots)
            {
                if (slot.name == this.name)
                {
                    _slot = slot;
                    slot.Toggle(_currentSwitch, this);
                }
            }

            if (_currentSwitch == Switch.ToggleUp)
            {
                _switchboard2.MakeTheCall();
    
            }
            else if (_currentSwitch == Switch.ToggleDown)
            {
                _switchboard2.NotReadyToCall();
                
            }
        }
    }

    //public void PopulateIncomingCaller(SwitchboardSO incomingCallerSwitchboard2)
    //{
    //    _incomingCall = incomingCallerSwitchboard2;

    //}

    //public void PopulateOutgoingCallee(SwitchboardSO outgoingCalleeSwitchboard2)
    //{
    //    _outgoingCallee = outgoingCalleeSwitchboard2;
    //}

    public void OnToggleClicked()
    {
        ++i;
        try
        {
            if (i == 1)
            {
                _mainToggle.sprite = _toggleUp;
                _currentSwitch = Switch.ToggleUp;
                _incomingWireGO = FindObjectOfType<IncomingWire>(true); //finds incoming wire even if it's inactive
                if (_incomingWireGO == null)          // if incoming wire is null
                {
                    //have popup saying "no answer" or "no one is on the line and fade out" and dial tone sound fx playing
                    _switchboard2.NotReadyToCall();
                }
                else                                //else
                {
                    _switchboard2.IncomingCall();   //set _incomingCaller = _incomingCalls[_callCount] and populate incoming caller
                    _outgoingWireGO = FindObjectOfType<OutgoingWire>(true);
                    if (_outgoingWireGO == null)
                    {
                        _outgoingWire = Instantiate(_outgoingWirePrefab, _incomingWireGO.GetComponent<IncomingWire>().ReturnIncomingWireEnd(), Quaternion.identity);
                    }
                    _outgoingWire.GetComponent<OutgoingWire>().ConnectOutgoingAnchorToJack(_outgoingWire.transform.position);
                    _switchboard2.ReadyToCall();
                }
            }
            else if (i == 2)
            {
                _mainToggle.sprite = _toggleDown;
                _currentSwitch = Switch.ToggleDown;
                i = 0;
                if (_switchboard2.IsCallCompleted() && _incomingWireGO != null)
                {
                    _switchboard2.ClearComingAndGoing();

                }
                _slot.TurnOffLight();
                _slot.IncomingInstantiatedReset();
                _switchboard2.StateMachineIdle();
                _switchboard2.NotReadyToCall();
                DisconnectWires();
            }
        }
        catch (Exception e)
        {
            Debug.Log("exception" + e);
        }
    } 
    public SwitchboardSO ReturnCallee()
    {
        return _outgoingCallee;
    }

    public void DisconnectWires()
    {
        //_incomingWireGO.GetComponent<IncomingWire>().DisconnectIncoming();
        Destroy(_outgoingWire);
        _outgoingWireGO.GetComponent<OutgoingWire>().DisconnectOutgoing();
    }
}

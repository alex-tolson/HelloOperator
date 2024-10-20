using System.Collections.Generic;
using UnityEngine;

public class Switchboard2 : MonoBehaviour
{
    //when both lights turn off, the call has ended.
    //player turns switch down.

    //-----Switchboard-----------------
    [SerializeField] private SwitchboardInv _switchboardInv; //--->try this instead of the singleton
    [SerializeField] CurrentState _currentState;
    [SerializeField] private List<string> _incomingCalls = new List<string>();
    //
    [SerializeField] private SwitchboardSO _incomingCall;
    [SerializeField] private SwitchboardSO _outgoingCall;
    [SerializeField] private List<LightsSlot>  _slots = new List<LightsSlot>();
    //
    private int _day = 1;
    private string _incomingCaller;
    [SerializeField] private int _callCount = 0;
    [SerializeField] private bool _incomingCallCompleted;

    //--------End Switchboard ---------
    //[SerializeField] private BellCall _bell;
    [SerializeField] private bool _callInitialize = false;
    private OutgoingWire _outgoingWire;

    private void Start()
    {
        GameObject.Find("SwitchboardLights").GetComponentsInChildren<LightsSlot>(true, _slots);
        if (_slots.Count == 0)
        {
            Debug.LogError("Switchboard2::StartMethod:: Light slots is null");
        }
        //----------------------------
        _currentState = CurrentState.Idle;
        _switchboardInv = GameObject.Find("GameManager").GetComponent<SwitchboardInv>();
        if (_switchboardInv == null)
        {
            Debug.LogError("Switchboard2::_switchboardInv is null");
        }
        //-----------------------------
        _outgoingWire = GameObject.FindObjectOfType<OutgoingWire>();

        InitializeAllCallsDay1();
        UpdateUI();

    }

    void Update()
    {
       
    }

    public void InitializeAllCallsDay1()
    {
        _incomingCalls.Add("A0");
        _incomingCalls.Add("A9");
        _incomingCalls.Add("C7");
        _incomingCalls.Add("C8");
        _incomingCalls.Add("Z1");
        _incomingCalls.Add("Z2");
        _incomingCalls.Add("Z2");
        _incomingCalls.Add("Y9");
        _incomingCalls.Add("A1");

    }

    private void InitializeAllCallsDay2()
    {
        _incomingCalls.Add("A0");
        _incomingCalls.Add("A9");
        _incomingCalls.Add("C7");
        _incomingCalls.Add("C8");
        _incomingCalls.Add("Z1");
        _incomingCalls.Add("Z2");
        _incomingCalls.Add("Z2");
        _incomingCalls.Add("Y9");
        _incomingCalls.Add("A1");
    }

    public void InitiateCall()
    {
        if (_callCount == _incomingCalls.Count)
        {
            Debug.Log("End of Day");
            //_callCount = 0;
        }
        else
        {
            _callInitialize = true;
            IncomingCall();
        }
    }

    private void IncomingCall()
    {
        _incomingCallCompleted = false;               //set call to not yet completed

        if (_incomingCallCompleted == false)      // if call not yet completed
        {
            _incomingCaller = _incomingCalls[_callCount];  //set IncomingCaller to incomingCalls[_callCount]
            Debug.Log("_incomingCaller name is " + _incomingCaller);
        }

        foreach (SwitchboardSO placement in _switchboardInv._switchboardList) //go through switchboard placement list
        {
            if (placement.placementName == _incomingCaller)//if the incoming call matches the incoming Caller from the List
            {
                _incomingCall = placement;
                _currentState = CurrentState.Ringing;

                foreach (LightsSlot slot in _slots) //iterate through the light slot list
                {
                    if (slot.name == _incomingCall.name) //if light slot name matches the incoming call
                    {
                        slot._light.gameObject.SetActive(true);//turn on light
                        slot._light.color = Color.yellow; //turn light yellow
                    }
                }
            }
        }
        _incomingCallCompleted = true;
        _callCount++;
        _incomingCallCompleted = false;
        _callInitialize = false;
    }

    private void InitializeIncomingCalls()
    {
        switch (_day)
        {
            case 1:
                {
                    InitializeAllCallsDay1();
                    break;
                }
            case 2:
                {
                    InitializeAllCallsDay2();
                    break;
                }
        }
    }

    public void UpdateUI()
    {
    
        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].AddLights(_switchboardInv._switchboardList[i]);
        }
    }

    public void OutgoingCallInitiate(SwitchboardSO outgoingCall)
    {
        _outgoingCall = outgoingCall;

    }
    public void SetIncomingJack(IncomingJack jack)
    {
       // _incomingCall.incomingLocation = jack;
       // _incomingCall.incomingLocation.transform.position = jack.transform.position;
    }

    //if incoming and outgoing on switchboard and jacks are occupied -->Done
    //the lights at the incoming and outgoing switchboard locations turn green-->Done
    //when the switches are flipped,
    //the switch cannot be flipped again until the dialogue is exhausted or skipped
    //then the switch can be flipped down and the lights go off.


}


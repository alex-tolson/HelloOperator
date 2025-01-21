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
    [SerializeField] private List<LightsSlot> _slots = new List<LightsSlot>();
    //
    [SerializeField] private int _day = 1;
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

    public void InitializeAllCallsDay1()
    {
        _incomingCalls.Add("A8");
        _incomingCalls.Add("C6");
        _incomingCalls.Add("C7");
        _incomingCalls.Add("Z0");
        _incomingCalls.Add("Z1");
        _incomingCalls.Add("Z1");
        _incomingCalls.Add("Y8");
        _incomingCalls.Add("A0");

    }

    private void InitializeAllCallsDay2()
    {
        _incomingCalls.Add("A8");
        _incomingCalls.Add("A7");
        _incomingCalls.Add("A4");
        _incomingCalls.Add("X3");
        _incomingCalls.Add("B8");
        _incomingCalls.Add("C5");
        _incomingCalls.Add("B2");
        _incomingCalls.Add("Y2");
    }

    public void InitiateCall()
    {
        _incomingCallCompleted = false;
        if (_callCount > _incomingCalls.Count) //> greater than not == to
        {
            Debug.Log("End of Day");
            //Confirm End of Day button 
            //Run the narration
            //restart the count
            AdvanceDay();
            AdvanceCallCount();
            InitializeIncomingCalls();
            //initialize new day's calls
            //InitializeIncomingCalls();
        }
        else
        {
            //Debug.Log("Initating call");
            _callInitialize = true;
            IncomingCall();
        }
    }

    private void IncomingCall()
    {
        if (_incomingCallCompleted == false) //if the call is not completed
        {
            _incomingCaller = _incomingCalls[_callCount];//incoming caller string equals _incoming calls[callCount]
        }

        foreach (SwitchboardSO placement in _switchboardInv._switchboardList)//cycle through the switchboard list
        {
            if (placement.placementName == _incomingCaller)//if switchboard list selection equals incoming caller
            {
                _incomingCall = placement;   //set incoming call to switchboard selection
                _currentState = CurrentState.Ringing; //current state of switchboard is ringing

                foreach (LightsSlot slot in _slots) //set the light selection to switchboard incoming call name
                {
                    if (slot.name == _incomingCall.name)
                    {
                        slot._light.gameObject.SetActive(true);
                        slot._light.color = Color.yellow;
                    }
                }
            }
        }
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

    //when the switches are flipped,
    //the switch cannot be flipped again until the dialogue is exhausted or skipped
    //then the switch can be flipped down and the lights go off.

    public bool IsOutgoingNull()
    {
        if (_outgoingCall != null)
            return false;
        else
            return true;
    }
    public int WhatDayItIs()
    {
        return _day;
    }
    public int CallCount()
    {
        return _callCount;
    }
    public SwitchboardSO WhoIsCalling()
    {
        return _incomingCall;
    }
    public SwitchboardSO WhoIsAnswering()
    {
        return _outgoingCall;
    }
    public void AdvanceCallCount()
    {
        _callCount++;
    }
    public void AdvanceDay()
    {
        _day++;
    }

    public bool IsCallCompleted()
    { 
        return _incomingCallCompleted;
    }
    public void CallIsComplete()
    {
        _incomingCallCompleted = true;
        _callInitialize = false;
    }

    public void ClearComingAndGoing()
    {
        _incomingCall = null;
        _outgoingCall = null;
    }
}


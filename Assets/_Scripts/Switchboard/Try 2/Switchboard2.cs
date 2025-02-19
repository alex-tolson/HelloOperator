using System.Collections.Generic;
using UnityEngine;

public class Switchboard2 : MonoBehaviour
{
    //when both lights turn off, the call has ended.
    //player turns switch down.

    //-----Switchboard-----------------
    [SerializeField] private SwitchboardInv _switchboardInv; //--->try this instead of the singleton
    private CallManager _callManager;
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
    // private OutgoingWire _outgoingWire;

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
        _callManager = GameObject.Find("Switchboard").GetComponent<CallManager>();
        //-----------------------------

        InitializedCalls(1);
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetDay();
            Debug.Log("Advancing day to " + _day + " and call " + _callCount);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            AdvanceCallCount();
            CallIsComplete();
            Debug.Log("Advancing day to " + _day + " and call " + _callCount);
        }
            
    }

    public void CallComingThru()
    {
        foreach (LightsSlot slot in _slots)
        {
            if (slot.name == _incomingCalls[_callCount])
            {
                slot.TurnLightColor(Color.yellow);
                slot.gameObject.SetActive(true);
            }
        }
    }

    public void InitializedCalls(int day)
    {
        switch (day)
        { 
            case 1:
                {
                    _incomingCalls.Clear();
                    _incomingCalls.Add("A8");
                    _incomingCalls.Add("C6");
                    _incomingCalls.Add("C7");
                    _incomingCalls.Add("Z0");
                    _incomingCalls.Add("Z1");
                    _incomingCalls.Add("Z1");
                    _incomingCalls.Add("Y8");
                    _incomingCalls.Add("A0");
                    break;
                }
            case 2:
                {
                    _incomingCalls.Clear();
                    _incomingCalls.Add("A8");
                    _incomingCalls.Add("A7");
                    _incomingCalls.Add("A4");
                    _incomingCalls.Add("X3");
                    _incomingCalls.Add("B8");
                    _incomingCalls.Add("C5");
                    _incomingCalls.Add("B2");
                    _incomingCalls.Add("Y2");
                    break;
                }
            case 3:
                {
                    _incomingCalls.Clear();
                    if (_callManager.Return_call_2_5_Sanford()==true)
                    {
                        _incomingCalls.Add("Y9");
                    }
                    else
                    {
                        _incomingCalls.Add("A1");
                    }

                    _incomingCalls.Add("X4");
                    _incomingCalls.Add("C5");
                    _incomingCalls.Add("A3");
                    _incomingCalls.Add("Y1");
                    _incomingCalls.Add("Y5");
                    _incomingCalls.Add("Y3");
                    break;
                }
            case 4:
                {
                    _incomingCalls.Clear();
                    _incomingCalls.Add("Y4");
                    _incomingCalls.Add("Y1");
                    _incomingCalls.Add("A2");
                    _incomingCalls.Add("Y8");
                    _incomingCalls.Add("Y1");
                    _incomingCalls.Add("Y1");
                    _incomingCalls.Add("A5");
                    _incomingCalls.Add("Y1");
                    break;
                }
            case 5:
                {
                    _incomingCalls.Clear();
                    _incomingCalls.Add("C7");
                    _incomingCalls.Add("Z1");
                    _incomingCalls.Add("X0");
                    _incomingCalls.Add("B6");
                    _incomingCalls.Add("X5");
                    _incomingCalls.Add("X7");
                    _incomingCalls.Add("A1");
                    _incomingCalls.Add("A8");

                    break;
                }
            case 6:
                {
                    _incomingCalls.Clear();
                    _incomingCalls.Add("Z3");
                    _incomingCalls.Add("Y0");
                    _incomingCalls.Add("C1");
                    _incomingCalls.Add("Z3");
                    _incomingCalls.Add("A9");
                    _incomingCalls.Add("Z9");
                    _incomingCalls.Add("A8");
                    _incomingCalls.Add("Z3");
                    _incomingCalls.Add("Z3");
                    break;
                }
            case 7:
                {
                    _incomingCalls.Clear();
                    _incomingCalls.Add("Y5");
                    _incomingCalls.Add("Y2");
                    _incomingCalls.Add("X0");
                    _incomingCalls.Add("Y2");
                    _incomingCalls.Add("C5");
                    _incomingCalls.Add("B1");
                    break;
                }
            case 8:
                {
                    _incomingCalls.Clear();
                    _incomingCalls.Add("A0");
                    _incomingCalls.Add("A2");
                    _incomingCalls.Add("C6");
                    if (_callManager.Return_call_5_5_Walskin() == true)
                    {
                        _incomingCalls.Add("Z2");
                    }
                    else
                    {
                        _incomingCalls.Add("Z8");
                    }
                    _incomingCalls.Add("A4");
                    break;
                }

        }


    }

    public void InitiateCall()
    {
        Debug.Log(_callCount + " | call count  | " + _incomingCalls.Count+ " _incomingCalls.Count");
        _incomingCallCompleted = false;
        if (_callCount == _incomingCalls.Count)
        {
            //hide text in text box
            //hide continue and skip buttons
            //display next day button
            //play animatic
            ResetDay();
            //
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

                //foreach (LightsSlot slot in _slots) //set the light selection to switchboard incoming call name
                //{
                //    if (slot.name == _incomingCall.name)
                //    {
                //        slot._light.gameObject.SetActive(true);
                //        slot._light.color = Color.yellow;
                //    }
                //}
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

    public void ResetDay()
    {
        Debug.Log("End of day.  Resetting values");
        AdvanceDay();
        ResetCallCount();
        InitializedCalls(_day);
        //have End the Day button pop up
        //clicking the End the Day button triggers cut scene

    }

    public SwitchboardSO ReturnIncomingCall()
    {
        return _incomingCall;
    }

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

    private void ResetCallCount()
    {
        _callCount = 0;
    }

}


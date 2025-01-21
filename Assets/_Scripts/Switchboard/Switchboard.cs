using System.Collections.Generic;
using UnityEngine;

public class Switchboard : MonoBehaviour
{
    //when bell is hit
    //a call comes through --- need a list of all available callers
    //player clicks on lit up area
    //a wire connects lit up area to the switchboard
    //Player selects where to place the call
    //Player connects wire to outgoing jack
    //player hits switch up to connect the call
    //both lights turn green as they are connected
    //when both lights turn off, the call has ended.
    //player turns switch down.

    //[SerializeField] private List<SwitchboardLights> _switchboardLights = new List<SwitchboardLights>();
    //[SerializeField] private List<string> _incomingCalls = new List<string>();

    //private int _day = 1;
    //private string _incomingCaller;
    //[SerializeField] private int _callCount = 0;
    //[SerializeField] private bool _incomingCallCompleted;
    //--------------------------------
    //[SerializeField] private BellCall _bell;
    //[SerializeField] private bool _callInitialize = false;
    //private OutgoingWire _outgoingWire;

    //private void Start()
    //{
    //    _outgoingWire = GameObject.FindObjectOfType<OutgoingWire>();
    //    InitializeIncomingCalls();  //Initiate the calls on the list for that day
    //    InitializeAllSwitchboardLights();
    //}

    //void Update()
    //{
    //    if (_callInitialize)
    //    {
    //        IncomingCall();
    //    }
    //}

    //public void InitializeAllCallsDay1()
    //{
    //    _incomingCalls.Add("A0");
    //    _incomingCalls.Add("A9");
    //    _incomingCalls.Add("C7");
    //    _incomingCalls.Add("C8");
    //    _incomingCalls.Add("Z1");
    //    _incomingCalls.Add("Z2");
    //    _incomingCalls.Add("Z2");
    //    _incomingCalls.Add("Y9");
    //    _incomingCalls.Add("A1");

    //}

    //private void InitializeAllCallsDay2()
    //{
    //    _incomingCalls.Add("A0");
    //    _incomingCalls.Add("A9");
    //    _incomingCalls.Add("C7");
    //    _incomingCalls.Add("C8");
    //    _incomingCalls.Add("Z1");
    //    _incomingCalls.Add("Z2");
    //    _incomingCalls.Add("Z2");
    //    _incomingCalls.Add("Y9");
    //    _incomingCalls.Add("A1");
    //}

    //private void InitializeAllSwitchboardLights()
    //{
    //    adds all lights to the switchboard lights List
    //    GameObject.Find("SwitchboardLights").GetComponentsInChildren<SwitchboardLights>(true, _switchboardLights);

    //    Debug.Log("switchboard count is " + _switchboardLights.Count);
    //    if (_switchboardLights == null)
    //    {
    //        Debug.LogError("Switchboard::SwitchboardLights is null");
    //    }
    //}

    //public void InitiateCall()
    //{
    //    if (_callCount == _incomingCalls.Count)
    //    {
    //        Debug.Log("End of Day");
    //        _callCount = 0;
    //    }
    //    else
    //    {
    //        _callInitialize = true;
    //        IncomingCall();
    //    }
    //}

    //private void IncomingCall()
    //{
    //    _incomingCallCompleted = false;               //set call to not yet completed

    //    if (_incomingCallCompleted == false)      // if call not yet completed
    //    {
    //        _incomingCaller = _incomingCalls[_callCount];  //set IncomingCaller to incomingCalls[_callCount]
    //    }

    //    foreach (string incomingCall in _incomingCalls)//go through call list
    //    {
    //        if (incomingCall == _incomingCaller)//if the incoming call matches the incoming Caller from the List
    //        {
    //            foreach (SwitchboardLights light in _switchboardLights)
    //            {
    //                if (light.name == _incomingCaller) //if  switchboardLight name == _incoming caller
    //                {
    //                    light.TurnLightColor(Color.yellow);//turn on switchboardLight
    //                }
    //            }
    //        }
    //    }
    //    _incomingCallCompleted = true;
    //    _callCount++;
    //    _incomingCallCompleted = false;
    //    _callInitialize = false;
    //}

    //private void InitializeIncomingCalls()
    //{
    //    switch (_day)
    //    {
    //        case 1:
    //            {
    //                InitializeAllCallsDay1();
    //                break;
    //            }
    //        case 2:
    //            {
    //                InitializeAllCallsDay2();
    //                break;
    //            }
    //    }
    //}

    //if incoming and outgoing on switchboard and jacks are occupied -->Done
    //the lights at the incoming and outgoing switchboard locations turn green-->Done
    //when the switches are flipped,
    //the lights at the incoming and outgoing switchboard locations turn Blue
    //the switch cannot be flipped again until the dialogue is exhausted or skipped
    //then the switch can be flipped down and the lights go off.


}

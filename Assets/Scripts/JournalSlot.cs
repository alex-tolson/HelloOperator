using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalSlot : MonoBehaviour
{
    [SerializeField] private Caller _newCaller;
    [SerializeField] private int _callerID;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private string _occupation;
    [SerializeField] private string _location;
    [SerializeField] private GameObject _activeLight;
    [SerializeField] private GameObject _switchState;
    [SerializeField] private SpriteRenderer _incomingCallerPlug;
    [SerializeField] private SpriteRenderer _outgoingCalleePlug;
    JournalInv journal;

    private void Awake()
    {
        journal = JournalInv.Instance;
    }

    public void AddCaller(Caller newCaller)
    {
        Debug.Log("adding new caller");

        _newCaller = newCaller;
        _callerID = newCaller.callerID;
        _name = newCaller.callerName;
        _icon = newCaller.callerIcon;
        _occupation = newCaller.callerOccupation;
        _location = newCaller.callerLocation;
        _activeLight = newCaller.callerActiveLight;
        _switchState = newCaller.callerSwitchState;
        _incomingCallerPlug = newCaller.incomingCallerPlug;
        _outgoingCalleePlug = newCaller.outgoingCalleePlug;
    }

    public void ClearSlot()
    {
        Debug.Log("clearing slot");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalSlot : MonoBehaviour
{
    private Caller _newCaller;
    private int _callerID;
    private Image _callerIcon;
    private TMP_Text _callerName;
    private TMP_Text _occupation;
    private TMP_Text _description;

    private TMP_Text _location;
    private GameObject _activeLight;
    private GameObject _switchState;
    private SpriteRenderer _incomingCallerPlug;
    private SpriteRenderer _outgoingCalleePlug;

    JournalInv journal;
    

    private void Awake()
    {
        journal = JournalInv.Instance;
    }

    public void AddCaller(Caller caller)
    {
        Debug.Log("adding new caller");

        _newCaller = caller;
        _callerID = caller.callerID;
        _callerName.text = caller.callerName;
        _occupation.text = caller.callerOccupation;
        _description.text = caller.description;

        //_location.text = caller.callerLocation;
        //_icon.sprite = caller.callerIcon;
        //_activeLight = caller.callerActiveLight;
        //_switchState = caller.callerSwitchState;
        //_incomingCallerPlug = caller.incomingCallerPlug;
        //_outgoingCalleePlug = caller.outgoingCalleePlug;
    }

    public void ClearSlot()
    {
        Debug.Log("clearing slot");
        _newCaller = null;
        _callerID = 9999;
        _callerName.text = "";
        _occupation.text = "";
        _description.text = "";

        //_icon = null;
        //_location.text = "";
        //_activeLight = null;
        //_switchState = null;
        //_incomingCallerPlug = null;
        //_outgoingCalleePlug = null;

    }
}

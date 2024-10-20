using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalSlot : MonoBehaviour
{
    [SerializeField] private Caller _newCaller;
    [SerializeField] private int _id;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _cName;
    [SerializeField] private TMP_Text _occupation;
    [SerializeField] private TMP_Text _location;
    [SerializeField] private TMP_Text _description;


    public void AddCaller(Caller caller)
    {
        //Debug.Log("adding new caller");

        _newCaller = caller;
        _newCaller.callerID = caller.callerID;
        _newCaller.callerIcon = caller.callerIcon;
        _newCaller.cName = caller.cName;
        _newCaller.callerOccupation = caller.callerOccupation;
        _newCaller.description = caller.description;

        _id = _newCaller.callerID;
        _cName.text = _newCaller.cName;
        _occupation.text = _newCaller.callerOccupation;
        _location.text = _newCaller.callerLocation;
        _description.text = _newCaller.description;
        //_icon.sprite = caller.callerIcon;
        //_activeLight = caller.callerActiveLight;
        //_switchState = caller.callerSwitchState;
        //_incomingCallerPlug = caller.incomingCallerPlug;
        //_outgoingCalleePlug = caller.outgoingCalleePlug;
    }

    public void ClearSlot()
    {
        //Debug.Log("clearing slot");
        _newCaller = null;

    }
}

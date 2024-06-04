using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalSlot : MonoBehaviour
{
     private Caller _newCaller;
    [SerializeField] private int _callerID;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _occupation;
    [SerializeField] private TMP_Text _location;
    [SerializeField] private TMP_Text _description;
    /*[SerializeField]*/
    private GameObject _activeLight;
    /*[SerializeField]*/ private GameObject _switchState;
    /*[SerializeField]*/ private SpriteRenderer _incomingCallerPlug;
    /*[SerializeField]*/ private SpriteRenderer _outgoingCalleePlug;
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
        _name.text = newCaller.callerName;
        //_icon.sprite = newCaller.callerIcon;
        _occupation.text = newCaller.callerOccupation;
        _location.text = newCaller.callerLocation;
        _description.text = newCaller.description;
        _activeLight = newCaller.callerActiveLight;
        _switchState = newCaller.callerSwitchState;
        _incomingCallerPlug = newCaller.incomingCallerPlug;
        _outgoingCalleePlug = newCaller.outgoingCalleePlug;
    }

    public void ClearSlot()
    {
        Debug.Log("clearing slot");
        _newCaller = null;
        _callerID = 0;
        _name = null;
        _icon = null;
        _occupation = null;
        _location = null;
        _activeLight = null;
        _switchState = null;
        _incomingCallerPlug = null;
        _outgoingCalleePlug = null;

    }
}

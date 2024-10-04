using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutgoingWire : MonoBehaviour, IPointerClickHandler
{
    //when the incoming wire is attached
    //attach the 2nd wire into outgoing
    [SerializeField] private OutgoingJack[] _outgoingJacks;
    [SerializeField] private AnchorPlaceHolder[] _anchorPlaceholder;
    private float _currentDistanceToJack;
    private float _oldDistanceToJack;
    private float _currentDistToAnchor;
    private float _oldDistToAnchor;
    [SerializeField] private OutgoingJack _jack;
    [SerializeField] private GameObject _outgoingWire;
    [SerializeField] private GameObject _outgoingBeginAnchor;
    [SerializeField] private GameObject _outgoingWireEndAnchor;
    [SerializeField] private Vector3 _offsetOutWireAtBegin;
    [SerializeField] private Vector3 _offsetOutWireAtEnd;



    private void OnEnable()
    {
        _outgoingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<OutgoingJack>();
        if (_outgoingJacks.Length == 0)
        {
            Debug.LogError("OutgoingWire::OutgoingJacks array is empty");
        }
        _anchorPlaceholder = GameObject.Find("SwitchboardPlaceHolders").GetComponentsInChildren<AnchorPlaceHolder>();
        if (_anchorPlaceholder.Length == 0)
        {
            Debug.LogError("OutgoingWire::AnchorPlaceholder array is empty");
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //select the nearest switchboard placeholder to connect to
        ConnectOutgoingAnchorToSwitchboard();
    }

    public void ConnectOutgoingAnchorToSwitchboard()
    {
        _currentDistToAnchor = 1;

        foreach (AnchorPlaceHolder anchor in _anchorPlaceholder)
        {
            _oldDistToAnchor = anchor.FindNearestPlaceHolder(_outgoingWireEndAnchor.transform.position);

            if (_oldDistToAnchor < _currentDistToAnchor)
            {
                _currentDistToAnchor = _oldDistToAnchor;
                _outgoingWireEndAnchor.transform.position = anchor.transform.position;
            }
        }
        _outgoingWireEndAnchor.transform.position = _outgoingWireEndAnchor.transform.position + _offsetOutWireAtEnd;

    }

    public void ConnectOutgoingAnchorToJack()
    {
        _currentDistanceToJack = 3;
        for (int i = 0; i < _outgoingJacks.Length; i++)
        {
            _oldDistanceToJack = _outgoingJacks[i].FindNearestOutgoingJack(_outgoingBeginAnchor.transform.position);

            if (_oldDistanceToJack < _currentDistanceToJack)
            {
                _currentDistanceToJack = _oldDistanceToJack;
                _jack = _outgoingJacks[i];     
            }
        }
        _outgoingBeginAnchor.transform.position = _jack.transform.position + _offsetOutWireAtBegin;
    }
}

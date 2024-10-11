using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutgoingWire : MonoBehaviour, IPointerClickHandler
{
    //when the incoming wire is attached
    //attach the 2nd wire into outgoing
    [SerializeField] private OutgoingJack[] _outgoingJacks;
    [SerializeField] private AnchorPlaceHolder[] _anchorPlaceholder;
    [SerializeField] private List<SwitchboardLights> _switchboardLights = new List<SwitchboardLights>();

    private float _currentDistanceToJack;
    private float _oldDistanceToJack;
    private float _currentDistToAnchor;
    private float _oldDistToAnchor;
    private float _currentDistToLight;
    private float _oldDistToLight;

    [SerializeField] private OutgoingJack _jack;
    [SerializeField] private AnchorPlaceHolder _switchboardPosition;
    [SerializeField] private SwitchboardLights _light;

    [SerializeField] private GameObject _outgoingWire;
    [SerializeField] private GameObject _outgoingWireParent;
    [SerializeField] private GameObject _outgoingWireEndAnchor;
    [SerializeField] private Vector3 _offsetOutWireAtBegin;
    [SerializeField] private Vector3 _offsetOutWireAtEnd;


    //have a dot or have mouse change shape when near clickable wire edge

    private void OnEnable()
    {
        _outgoingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<OutgoingJack>();
        _anchorPlaceholder = GameObject.Find("AnchorPlaceHolders").GetComponentsInChildren<AnchorPlaceHolder>();
        GameObject.Find("SwitchboardLights").GetComponentsInChildren<SwitchboardLights>(true, _switchboardLights);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //select the nearest switchboard placeholder to connect to
        ConnectOutgoingAnchorToSwitchboard();
        EstablishConnection();
    }

    public void ConnectOutgoingAnchorToSwitchboard()
    {
        _currentDistToAnchor = 1;
        for (int i = 0; i < _anchorPlaceholder.Length; i++)
        {
            _oldDistToAnchor = _anchorPlaceholder[i].FindNearestPlaceHolder(_outgoingWireEndAnchor.transform.position);

            if (_oldDistToAnchor < _currentDistToAnchor)
            {
                _currentDistToAnchor = _oldDistToAnchor;
                _switchboardPosition = _anchorPlaceholder[i];
            }
        }
        Debug.Log("anchor name is " + _switchboardPosition.name);
        _outgoingWireEndAnchor.transform.position = _switchboardPosition.transform.position + _offsetOutWireAtEnd;
    }

    public void ConnectOutgoingAnchorToJack(Vector3 position)
    {
        _currentDistanceToJack = 3;
        for (int i = 0; i < _outgoingJacks.Length; i++)
        {
            _oldDistanceToJack = _outgoingJacks[i].FindNearestOutgoingJack(position);

            if (_oldDistanceToJack < _currentDistanceToJack)
            {
                _currentDistanceToJack = _oldDistanceToJack;
                _jack = _outgoingJacks[i];
            }
        }
        Debug.Log("jack name is " + _jack.name);
        _outgoingWireParent.transform.position = _jack.transform.position + _offsetOutWireAtBegin;
    }

    public void EstablishConnection()
    {
        if (_jack != null && _switchboardPosition != null)
        {
            _currentDistToLight = 1;

            for (int i = 0; i < _switchboardLights.Count; i++)
            {
                _oldDistToLight = _switchboardLights[i].FindNearestLight(_outgoingWireEndAnchor.transform.position);
                if (_oldDistToLight < _currentDistToLight)
                {
                    _currentDistToLight = _oldDistToLight;
                    _light = _switchboardLights[i];
                }
            }
            _light.gameObject.SetActive(true);
            _light.TurnLightColor(Color.green);
        }
    }
}

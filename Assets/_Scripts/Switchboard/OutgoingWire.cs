using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutgoingWire : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private OutgoingJack[] _outgoingJacks;
    [SerializeField] private AnchorPlaceHolder[] _anchorPlaceholders;
    [SerializeField] private LightsSlot[] _switchboardLights;

    private float _currentDistanceToJack;
    private float _oldDistanceToJack;
    private float _currentDistToAnchor;
    private AnchorPlaceHolder _anchor;
    
    private float _currentDistToLight;
    private float _oldDistToLight;
    private Switchboard2 _switchboard2;

    [SerializeField] private OutgoingJack _jack;
    [SerializeField] private SwitchboardSO _switchboardPosition;
    [SerializeField] private LightsSlot _light;

    [SerializeField] private GameObject _outgoingWire;
    //[SerializeField] private GameObject _outgoingWireParent;
    [SerializeField] private GameObject _outgoingWireEndAnchor;
    [SerializeField] private Vector3 _offsetOutWireAtBegin;
    [SerializeField] private Vector3 _offsetOutWireAtEnd;
    [SerializeField] private Vector3 _worldSpacePos;
    [SerializeField] private float _oldDistToAnchor;

    private void OnEnable()
    {
        _outgoingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<OutgoingJack>();
        if (_outgoingJacks.Length == 0)
        {
            Debug.Log("OutgoingWire:: outgoing jacks array is empty");
        }
        _anchorPlaceholders = GameObject.Find("AnchorPlaceHolders").GetComponentsInChildren<AnchorPlaceHolder>();
        if (_anchorPlaceholders.Length == 0)
        {
            Debug.Log("OutgoingWire:: anchor placeholder array is empty");
        }
        _switchboardLights = GameObject.Find("SwitchboardLights").GetComponentsInChildren<LightsSlot>();
        if (_switchboardLights.Length == 0)
        {
            Debug.Log("OutgoingWire:: switchboard lights list is empty");
        }
    }
    private void Start()
    {
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("OutgoingWire::Switchboard2 is null");
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        ConnectOutgoingAnchorToSwitchboard();
        EstablishConnection();
    }

    public void ConnectOutgoingAnchorToSwitchboard()
    {
        _currentDistToAnchor = 3;

        for (int i = 0; i < SwitchboardInv.Instance._switchboardList.Count; i++)
        {
            _oldDistToAnchor = Vector3.Distance(_outgoingWireEndAnchor.transform.position, _anchorPlaceholders[i].transform.position);
            //SwitchboardInv.Instance._switchboardList[i]._vector3Location

            if (_oldDistToAnchor < _currentDistToAnchor)
            {
                _currentDistToAnchor = _oldDistToAnchor;
                _worldSpacePos = _anchorPlaceholders[i].transform.position;

                _switchboardPosition = SwitchboardInv.Instance._switchboardList[i];
                _switchboard2.OutgoingCallInitiate(SwitchboardInv.Instance._switchboardList[i]);
            }
        }
        _outgoingWireEndAnchor.transform.position = _worldSpacePos + _offsetOutWireAtEnd;
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
        transform.position = _jack.transform.position + _offsetOutWireAtBegin;
        Debug.Log("outgoing jack is : " + _jack);
    }

    public void EstablishConnection()
    {

        if (_jack != null && _switchboardPosition != null)
        {

            _currentDistToLight = 3;

            for (int i = 0; i < _switchboardLights.Length; i++)
            {
                _oldDistToLight = _switchboardLights[i].FindNearestLight(_outgoingWireEndAnchor.transform.position);
                if (_oldDistToLight < _currentDistToLight)
                {
                    _currentDistToLight = _oldDistToLight;
                    _light = _switchboardLights[i];
                }
            }
            _light.TurnLightOn();
        }
        else
        {
            Debug.LogError("OutgoingWire::EstablishConnection:: No connection established");
        }
    }

    public void DisconnectOutgoing()
    {
        Destroy(this);
    }
}


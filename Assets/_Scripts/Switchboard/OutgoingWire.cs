using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutgoingWire : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private OutgoingJack[] _outgoingJacks;
    //[SerializeField] private AnchorPlaceHolder[] _anchorPlaceholder;
    [SerializeField] private List<LightsSlot> _switchboardLights = new List<LightsSlot>();

    private float _currentDistanceToJack;
    private float _oldDistanceToJack;
    private float _currentDistToAnchor;
    
    private float _currentDistToLight;
    private float _oldDistToLight;
    private Switchboard2 _switchboard2;

    [SerializeField] private OutgoingJack _jack;
    [SerializeField] private SwitchboardSO _switchboardPosition;
    [SerializeField] private LightsSlot _light;

    [SerializeField] private GameObject _outgoingWire;
    [SerializeField] private GameObject _outgoingWireParent;
    [SerializeField] private GameObject _outgoingWireEndAnchor;
    [SerializeField] private Vector3 _offsetOutWireAtBegin;
    [SerializeField] private Vector3 _offsetOutWireAtEnd;
    [SerializeField] private Vector3 _worldSpacePos;

    [SerializeField] private float _oldDistToAnchor;
    //have a dot or have mouse change shape when near clickable wire edge

    private void OnEnable()
    {
        //_outgoingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<OutgoingJack>();
        //_anchorPlaceholder = GameObject.Find("AnchorPlaceHolders").GetComponentsInChildren<AnchorPlaceHolder>();
        // GameObject.Find("SwitchboardLights").GetComponentsInChildren<LightsSlot>(true, _switchboardLights);
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
        if (_light != null)
        {
            _light.TurnLightColor(Color.yellow);
            _light.gameObject.SetActive(false);
        }
        ConnectOutgoingAnchorToSwitchboard();
        EstablishConnection();
    }

    public void ConnectOutgoingAnchorToSwitchboard()
    {
        _currentDistToAnchor = 5;

        for (int i = 0; i < SwitchboardInv.Instance._switchboardList.Count; i++)
        {
            _oldDistToAnchor = Vector3.Distance(SwitchboardInv.Instance._switchboardList[i]._vector3Location,
                _outgoingWireEndAnchor.transform.position);

            if (_oldDistToAnchor < _currentDistToAnchor)
            {
                _currentDistToAnchor = _oldDistToAnchor;
                _switchboardPosition = SwitchboardInv.Instance._switchboardList[i];
                _switchboard2.OutgoingCallInitiate(SwitchboardInv.Instance._switchboardList[i]);
            }
        }
        _worldSpacePos = _switchboardPosition._vector3Location;
        _outgoingWireEndAnchor.transform.position = _worldSpacePos;
    }

    public void ConnectOutgoingAnchorToJack(Vector3 position)
    {
        _outgoingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<OutgoingJack>();

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
    }

    public void EstablishConnection()
    {
        GameObject.Find("SwitchboardLights").GetComponentsInChildren<LightsSlot>(true, _switchboardLights);

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
        }
        else
        {
            Debug.LogError("OutgoingWire::EstablishConnection:: No connection established");
        }
    }

    //if switch is down or toggled off,
    //disconnect wire


    public void DisconnectWire()
    {
        Destroy(gameObject);
    }
}


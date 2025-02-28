using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class LightsSlot : MonoBehaviour, IPointerClickHandler
{
    private SwitchboardSO _switchboardSO;
    [SerializeField] private Sprite _lightOn;
    [SerializeField] private Sprite _lightOff;
    [SerializeField] private Sprite _lightGreen;
    [SerializeField] private AnchorPlaceHolder[] _anchorPlaceHolders;
    public string _name;
    
    public JackDirection _direction;
    public CurrentState _currentState;
    public SpriteRenderer _light;
    //------------------------------------
    private Switchboard2 _switchboard2;
    [SerializeField] private GameObject _incomingWireGO;
    [SerializeField] private GameObject _outgoingWireGO;
    private GameObject _incomingWire;
    private GameObject _outgoingWire;
    [SerializeField] private bool _incomingInstantiated = false;
    [SerializeField] private Vector3 _incomingWirePositionOffset;
    [SerializeField] private IncomingJack _incomingJack;
    private GameObject _gameObjIncoming;
    private GameObject _gameObjOutgoing;


    private void Start()
    {
        _anchorPlaceHolders = GameObject.Find("AnchorPlaceHolders").GetComponentsInChildren<AnchorPlaceHolder>();
        if (_anchorPlaceHolders.Length == 0)
        {
            Debug.LogError("LightSlot::AnchorPlaceHolders array is empty");
        }

        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if(_switchboard2 == null)
        {
            Debug.LogError("LightsSlot::Switchboard2 is null");
        }
    }

    public void AddLights(SwitchboardSO switchboardScriptableObj)
    {
        _switchboardSO = switchboardScriptableObj;
        _name = switchboardScriptableObj.placementName;
        _direction = switchboardScriptableObj.jackDirection;
        _currentState = switchboardScriptableObj.currentState;
        _light = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_switchboardSO != null) // if switchboard scriptable object is not null
        {
            if (_incomingInstantiated == false)
            {
                //if this name == anchorplaceholder name
                //instantiate at position of anchor placeholder

                foreach (AnchorPlaceHolder placeHolder in _anchorPlaceHolders)
                {
                    if (this.name == placeHolder.name)
                    {
                         _gameObjIncoming = Instantiate(_incomingWireGO, placeHolder.transform.position, Quaternion.identity);

                        //_incomingWireGO.GetComponent<IncomingWire>().ConnectWireAtAnchor(this);
                        _incomingInstantiated = true;
                    }
                }
                //_switchboard2._gameObjIncoming.SetActive(!_switchboard2._gameObjIncoming.activeSelf);

            }
            else
            {
                _switchboard2.ClearComingAndGoing();
                _incomingInstantiated = false;
                TurnOffLight();
                Destroy(_gameObjIncoming);
            }
        }
    }

    public void Toggle(SwitchesAnim toggle)
    {
        try // change code so that who is calling is based on where the incoming wire snaps to
        {
            if (toggle.ToggleStatus() == Switch.ToggleUp)
            {
                //TurnLightColor(Color.green);
                _light.sprite = _lightGreen;
                //can skip but cannot flip toggle until dialogue is finished.

                //if (_light != null) //if _light is null return color to yellow and deactivate
                //{
                //    _light.sprite = _lightOff;
                //}

                if (_gameObjIncoming != null) //(_switchboard2.gameObj == null)
                {
                    //instantiate outgoing when switch is flipped up and connect to jack
                    _gameObjOutgoing = Instantiate(_outgoingWireGO, _incomingWireGO.GetComponent<IncomingWire>().ReturnIncomingWireEnd(), Quaternion.identity);
                    _gameObjOutgoing.GetComponent<OutgoingWire>().ConnectOutgoingAnchorToJack(_gameObjOutgoing.transform.position);
                }
                else
                {
                    return;
                }
            }

            if (toggle.ToggleStatus() == Switch.ToggleDown)
            {
                TurnOffLight();
                IncomingInstantiatedReset();
            }
        }
        catch (Exception e)
        {
            Debug.Log("exception" + e);
        }
    }

    //public void AttachLightToSwitch(SwitchesAnim toggle)
    //{
    //    TurnLightColor(Color.green);
    //}

    public void IncomingInstantiatedReset()
    {
        _incomingInstantiated = false;
    }

    public void TurnLightOn()
    {
        _light.sprite = _lightOn;
    }
    public void TurnLightGreen()
    {
        _light.sprite = _lightGreen;
    }

    public float FindNearestLight(Vector3 position)
    {
        var distance = Vector3.Distance(transform.position, position);
        return distance;
    }

    public void TurnOffLight()
    {
        _light.sprite = _lightOff;
    }

    public void DisconnectWires()
    {
        Destroy(_gameObjIncoming);
        Destroy(_gameObjOutgoing);
    }
}

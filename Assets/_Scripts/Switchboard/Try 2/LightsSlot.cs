using UnityEngine;
using UnityEngine.EventSystems;


public class LightsSlot : MonoBehaviour, IPointerClickHandler
{
    private SwitchboardSO _switchboardSO;
    private SwitchboardSO _incomingCaller;
    private SwitchboardSO _outgoingCallee;
    [SerializeField] private Sprite _lightOn;
    [SerializeField] private Sprite _lightOff;
    [SerializeField] private Sprite _lightGreen;
    private AnchorPlaceHolder[] _anchorPlaceHolders;
    private SwitchesAnim[] _switchesAnim;
    public string _name;
    private string _nameOfThisLightslot;
    
    public JackDirection _direction;
    public CurrentState _currentState;
    public SpriteRenderer _light;
    //------------------------------------
    private Switchboard2 _switchboard2;
    [SerializeField] private GameObject _incomingWireGO;
    private GameObject _incomingWire;
    private GameObject _outgoingWire;
    private bool _incomingInstantiated = false;
    [SerializeField] private Vector3 _bone1PositionOffset;
    [SerializeField] private Vector3 _bone20PositionOffset;
    [SerializeField] private GameObject _gameObjIncoming = null;
    private AudioManager _audioManager;

    //[SerializeField] private IncomingJack[] _incomingJacks;
    private Vector2 _incomingCableStartingPosition;
    private Vector2 _incomingCableEndingPosition;
    //[SerializeField] GameObject _bone_20;
    private bool _activated;

 
    private void Awake()
    {
        _nameOfThisLightslot = this.name;
    }
    private void Start()
    {
        _switchesAnim = GameObject.Find("Switch_Container").GetComponentsInChildren<SwitchesAnim>();
        if (_switchesAnim.Length == 0)
        {
            Debug.LogError("LightsSlot::Switches Anim array is empty.");
        }
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
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
                foreach (AnchorPlaceHolder placeHolder in _anchorPlaceHolders)
                {
                    if (_nameOfThisLightslot == placeHolder.name)
                    {
                        _activated = true;
                        _gameObjIncoming = Instantiate(_incomingWireGO, placeHolder.transform.position, Quaternion.identity);
                        _incomingCableStartingPosition = _gameObjIncoming.transform.position + _bone1PositionOffset;
                        _gameObjIncoming.GetComponent<IncomingWire>().ConnectWireAtAnchor(this);
                        _incomingInstantiated = true;
                        _audioManager.PlayRandomPlugin();
                    }

                }
            }
            else
            {
                //_activated = false;
                _audioManager.PlayRandomUnPlug();
                _switchboard2.ClearComingAndGoing();
                _incomingInstantiated = false;
                TurnOffLight();
                _gameObjIncoming = null;
            }
        }
    }

    public void Toggle(Switch toggle, SwitchesAnim _switch)
    {
        if (toggle == Switch.ToggleUp)
        { 
            _light.sprite = _lightGreen;
        }
        else if (toggle == Switch.ToggleDown)
        {
            Destroy(_gameObjIncoming);
            _switchboard2.NotReadyToCall();
        }

    }

    public Vector2 StartingPosition()
    {
        return _incomingCableStartingPosition;
    }

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
        Destroy(_gameObjIncoming);
    }

    public bool IsActivated()
    {
        return _activated;
    }
}

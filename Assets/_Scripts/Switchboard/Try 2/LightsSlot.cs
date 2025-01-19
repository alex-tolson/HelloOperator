using UnityEngine;
using UnityEngine.EventSystems;

public class LightsSlot : MonoBehaviour, IPointerClickHandler
{
    private SwitchboardSO _switchboard;
    public string _name;

    public JackDirection _direction;
    public CurrentState _currentState;
    public SpriteRenderer _light;
    //------------------------------------
    //private IncomingWire _incomingWire;
    [SerializeField] private GameObject _incomingWireGO;
    [SerializeField] private GameObject _outgoingWireGO;
    private Color _color;


    private void Start()
    {
        //_incomingWire = FindObjectOfType<IncomingWire>(true); //finds incoming wire even if it's inactive
        //if (_incomingWire == null)
        //{
        //    Debug.LogError("SwitchboardLights::Wires function is null");
        //}
    }

    public void AddLights(SwitchboardSO switchboardScriptableObj)
    {
        _switchboard = switchboardScriptableObj;
        _name = switchboardScriptableObj.placementName;
        _direction = switchboardScriptableObj.jackDirection;
        _currentState = switchboardScriptableObj.currentState;
        _light = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_switchboard != null)
        {
            gameObject.SetActive(false);

            //introduce wire
            Instantiate(_incomingWireGO, eventData.pointerCurrentRaycast.worldPosition, Quaternion.identity);
            _incomingWireGO.gameObject.SetActive(true);
            //incomingWire.gameObject.SetActive(true);
            _incomingWireGO.GetComponent<IncomingWire>().ConnectWireAtAnchor(this);
        }
    }

    public void Toggle(SwitchesAnim toggle)
    {
        if (toggle.ToggleStatus() == Switch.ToggleUp && toggle.gameObject.CompareTag("IncomingToggle"))
        {
            TurnLightColor(Color.green);
            //we want to turn light green
            //if the switchboard2.incoming wire is not null
            //
            //initiate dialoge coroutine
            //can skip but cannot flip toggle until dialogue is finished.
            if (_light != null)
            {
                TurnLightColor(Color.yellow);
                _light.gameObject.SetActive(false);
            }
            //instantiate outgoing when switch is flipped up
            Instantiate(_outgoingWireGO, _incomingWireGO.GetComponent<IncomingWire>().ReturnIncomingWireEnd(), Quaternion.identity);
            _outgoingWireGO.GetComponent<OutgoingWire>().ConnectOutgoingAnchorToJack(_outgoingWireGO.transform.position);
        }

        else if (toggle.ToggleStatus() == Switch.ToggleDown )
        {
            TurnOffLight();

        }
    }

    public void AttachLightToSwitch(SwitchesAnim toggle)
    {
        TurnLightColor(Color.green);
    }

    public void TurnLightColor(Color color)
    {
        gameObject.SetActive(true);
        _light.color = color;
    }

    public float FindNearestLight(Vector3 position)
    {
        var distance = Vector3.Distance(transform.position, position);
        return distance;
    }

    public void TurnOffLight()
    {
        TurnLightColor(Color.yellow);
        gameObject.SetActive(false);
    }


}

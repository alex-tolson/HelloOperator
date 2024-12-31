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
    private IncomingWire _incomingWire;
    private Color _color;


    private void Start()
    {
        _incomingWire = FindObjectOfType<IncomingWire>(true); //finds incoming wire even if it's inactive
        if (_incomingWire == null)
        {
            Debug.LogError("SwitchboardLights::Wires function is null");
        }
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
            _incomingWire.gameObject.SetActive(true);
            _incomingWire.ConnectWireAtAnchor(this);
        }
    }

    public void Toggle(SwitchesAnim toggle)
    {
        if (toggle.ToggleStatus() == Switch.ToggleUp)
        {
            TurnLightColor(Color.green);
            //we want to turn light green
            //if the switchboard2.incoming wire is not null
            //
            //initiate dialoge coroutine
            //can skip but cannot flip toggle until dialogue is finished.
        }
        else if(toggle.ToggleStatus() == Switch.ToggleDown)
        {
            //if toggle is down
            //reset communications?
            TurnOffLight();
            //turn light yellow/off
            //end dialogue.
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightsSlot : MonoBehaviour, IPointerClickHandler
{
    private SwitchboardSO _switchboard;
    public string _name;
    //public IncomingJack _incomingLocation;
    //public AnchorPlaceHolder _outgoingLocation;
    public Switch _switch;
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
    public void AddLights (SwitchboardSO switchboardScriptableObj)
    {
        _switchboard = switchboardScriptableObj;
        _name = switchboardScriptableObj.placementName;
        //_incomingLocation = switchboardScriptableObj.incomingLocation;
        //_outgoingLocation = switchboardScriptableObj.outgoingLocation;
        _switch = switchboardScriptableObj.placementSwitch;
        _direction = switchboardScriptableObj.jackDirection;
        _currentState = switchboardScriptableObj.currentState;
        _light = gameObject.GetComponent<SpriteRenderer>();
    }
  
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        _incomingWire.gameObject.SetActive(true);
        _incomingWire.ConnectWireAtAnchor(this);
    }

    public void TurnLightColor(Color color)
    {
        gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().color = color;
    }

    public float FindNearestLight(Vector3 position)
    {
        var distance = Vector3.Distance(transform.position, position);
        return distance;
    }

    public void TurnOffLight()
    {
        gameObject.SetActive(false);
    }
}

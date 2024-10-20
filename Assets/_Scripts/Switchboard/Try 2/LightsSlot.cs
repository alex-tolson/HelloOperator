using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
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
    private SwitchesAnim[] _switchesAnim;

    private void Start()
    {
        _switchesAnim = GameObject.Find("Switch_Container").GetComponentsInChildren<SwitchesAnim>();
        if (_switchesAnim.Length == 0)
        {
            Debug.LogError("LightsSlot::Switches Anim array is empty");
        }
        _incomingWire = FindObjectOfType<IncomingWire>(true); //finds incoming wire even if it's inactive
        if (_incomingWire == null)
        {
            Debug.LogError("SwitchboardLights::Wires function is null");
        }
    }
    private void Update()
    {
        Toggle();
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

    public void Toggle()
    {
        foreach (SwitchesAnim toggle in _switchesAnim)
        {
            if (toggle.name == _name)
            {
                if (toggle.ToggleStatus() == Switch.ToggleUp)
                {
                    //we want to do what?
                    //IF toggle is up
                    TurnLightColor(Color.green);
                    //we want to turn light green
                    //initiate dialoge coroutine
                    //can skip but cannot flip toggle until dialogue is finished.
                }
                if (toggle.ToggleStatus() == Switch.ToggleDown)
                {
                    //if toggle is down
                    //reset communications?
                    //TurnOffLight();
                    //turn light yellow/off
                    //end dialogue.
                }
            }
        }
    }

    public void AttachLightToSwitch(SwitchesAnim toggle)
    {
        Debug.Log("switch has been flipped");
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

using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class LightsSlot : MonoBehaviour, IPointerClickHandler
{
    private SwitchboardSO _switchboardSO;
    public string _name;
    
    public JackDirection _direction;
    public CurrentState _currentState;
    public SpriteRenderer _light;
    //------------------------------------
    private Switchboard2 _switchboard2;
    [SerializeField] private GameObject _incomingWireGO;
    [SerializeField] private GameObject _outgoingWireGO;
    [SerializeField] private bool _incomingInstantiated = false;
    [SerializeField] private Vector3 _incomingWirePositionOffset;
    [SerializeField] private IncomingJack _incomingJack;


    private void Start()
    {
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
                Instantiate(_incomingWireGO, eventData.pointerCurrentRaycast.worldPosition, Quaternion.identity);
                _incomingWireGO.gameObject.SetActive(true);
                _incomingWireGO.GetComponent<IncomingWire>().ConnectWireAtAnchor(this);
                _incomingInstantiated = true;  
            }
        }
    }

    public void Toggle(SwitchesAnim toggle)
    {
        try // change code so that who is calling is based on where the incoming wire snaps to
        {
            if (toggle.ToggleStatus() == Switch.ToggleUp)
            {
                TurnLightColor(Color.green);
                //can skip but cannot flip toggle until dialogue is finished.

                if (_light != null) //if _light is null return color to yellow and deactivate
                {
                    TurnLightColor(Color.yellow);
                    _light.gameObject.SetActive(false);
                }
                if (_switchboard2.gameObj == null)
                {
                    //instantiate outgoing when switch is flipped up and connect to jack
                    _switchboard2.gameObj = Instantiate(_outgoingWireGO, _incomingWireGO.GetComponent<IncomingWire>().ReturnIncomingWireEnd(), Quaternion.identity);
                    _outgoingWireGO.GetComponent<OutgoingWire>().ConnectOutgoingAnchorToJack(_outgoingWireGO.transform.position);
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

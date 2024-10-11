using UnityEngine;
using UnityEngine.EventSystems;

public class IncomingWire : MonoBehaviour, IPointerClickHandler
{
    private float _oldDistanceToJack;
    private float _currentDistanceToJack;
    private Vector3 _currentPos;

    [SerializeField] private IncomingJack[] _incomingJacks;
    [SerializeField] private GameObject _incomingWireAnchor;
    [SerializeField] private GameObject _incomingWireEnd;
    [SerializeField] private GameObject _incomingWireEndAnchor;
    [SerializeField] private Vector3 _wireOffsetAtEnd;
    [SerializeField] private Vector3 _wireOffsetAtLight;
    [SerializeField] private GameObject _outgoingWire;
    [SerializeField] private Transform _switchboardParent;

    //have a dot or have mouse change shape when near clickable wire edge


    private void OnEnable()
    {
        _incomingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<IncomingJack>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ConnectWireAtEnd();
        //Set up outgoing wire
        _outgoingWire.SetActive(true);
        _outgoingWire.GetComponent<OutgoingWire>().ConnectOutgoingAnchorToJack(_incomingWireEnd.transform.position);
    }

    public void ConnectWireAtEnd()
    {
        _currentDistanceToJack = 1;
        foreach (IncomingJack jack in _incomingJacks)
        {
            _oldDistanceToJack = jack.FindNearestIncomingJack(_incomingWireEnd.transform.position);

            if (_oldDistanceToJack < _currentDistanceToJack)
            {
                _currentDistanceToJack = _oldDistanceToJack;
                _incomingWireEndAnchor.transform.position = jack.transform.position;
            }
        }
        _incomingWireEnd.transform.position = _incomingWireEndAnchor.transform.position + _wireOffsetAtEnd;
    }

    public void ConnectWireAtAnchor(SwitchboardLights light)
    {
        _incomingWireAnchor.transform.position = light.transform.position + _wireOffsetAtLight;
        light.TurnLightColor(Color.green);
    }
    //if switch is flipped, 
    //turn corresponding light blue

}
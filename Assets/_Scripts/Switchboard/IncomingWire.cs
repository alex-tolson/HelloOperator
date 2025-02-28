using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncomingWire : MonoBehaviour, IPointerClickHandler
{
    private float _oldDistanceToJack;
    private float _currentDistanceToJack;
    //private Vector3 _currentPos;

    private Switchboard2 _switchboard2;
    [SerializeField] private IncomingJack[] _incomingJacks;
    [SerializeField] private GameObject _incomingWireAnchor;
    [SerializeField] private GameObject _incomingWireEnd;
    [SerializeField] private GameObject _incomingWireEndAnchor;
    [SerializeField] private Vector3 _wireOffsetOutgoing;
    [SerializeField] private Vector3 _wireOffsetIncoming;
    [SerializeField] private GameObject _outgoingWire;
    [SerializeField] private IncomingJack _jack;
   // [SerializeField] private Transform _switchboardParent;

    //have a dot or have mouse change shape when near clickable wire edge


    private void OnEnable()
    {
        _incomingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<IncomingJack>();
    }
    private void Start()
    {
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("IncomingWire::Switchboard2 is null");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { 

        }
    
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ConnectWireAtEnd();
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
                _incomingWireEndAnchor.transform.position = jack.transform.position + _wireOffsetIncoming;
                _jack = jack;
            }
        }
        _incomingWireEnd.transform.position = _incomingWireEndAnchor.transform.position ;
    }

    public IncomingJack ReturnJack()
    {
        return _jack;
    }

    public void ConnectWireAtAnchor(LightsSlot light)
    {
        _incomingWireAnchor.transform.position = light.transform.position;
    }

    public Vector3 ReturnIncomingWireEnd()
    {
        return _incomingWireEnd.transform.position + _wireOffsetOutgoing;
    }

}
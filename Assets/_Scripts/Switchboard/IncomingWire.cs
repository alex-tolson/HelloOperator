using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncomingWire : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
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
    [SerializeField] private OutgoingWire _outgoing;



    private void OnEnable()
    {
        _outgoing = FindObjectOfType<OutgoingWire>(true);
        if (_outgoing == null)
        {
            Debug.LogError("IncomingWire::Outgoing Wire is null");
        }
        _incomingJacks = GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<IncomingJack>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _outgoing.gameObject.SetActive(false);
        ConnectWireAtEnd();
        //Set up outgoing wire
        _outgoing.gameObject.SetActive(true);//
        _outgoing.transform.position = _incomingWireEnd.transform.position;
        _outgoing.ConnectOutgoingAnchorToJack();
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

    public void ConnectWireAtAnchor(Vector3 positionOfLight)
    {
        _incomingWireAnchor.transform.position = positionOfLight + _wireOffsetAtLight;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _outgoing.gameObject.SetActive(false);
    }
}
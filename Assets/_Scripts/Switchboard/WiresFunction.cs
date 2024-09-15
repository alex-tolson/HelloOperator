using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WiresFunction : MonoBehaviour, IPointerClickHandler//, IPointerMoveHandler, IPointerDownHandler, 
{
    //wire shows up attached from call on switchboard to mouse pointer
    //right-click to drop wire
    //left-click to pick up wire
    //ability to drag and drop wire to appropriate node
    //ability for wire to attach to closest node
    private float _oldDistance;
    private float _currentDistance;
    [SerializeField] private GameObject _wirePlaceholder;
    private Vector3 _currentPos;
    [SerializeField] private GameObject _wireEnd;
    [SerializeField] private List<IncomingJack> _incomingJacks = new List<IncomingJack>();
    [SerializeField] private Vector3 _wireOffset;
    private void Start()
    {
        GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<IncomingJack>(_incomingJacks);
    }
    public void ActivateWire()
    {
        gameObject.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("finding nearest jack");
        ConnectWire();
        
    }

    public void ConnectWire()
    {
        _currentDistance = 3;
        foreach (IncomingJack jack in _incomingJacks)
        {
            _oldDistance = jack.FindNearestJack(_wireEnd.transform.position);

            if (_oldDistance < _currentDistance)
            {
                _currentDistance = _oldDistance;
                _wirePlaceholder.transform.position = jack.transform.position;
            }
        }
        _wireEnd.transform.position = _wirePlaceholder.transform.position + _wireOffset;
    }
}

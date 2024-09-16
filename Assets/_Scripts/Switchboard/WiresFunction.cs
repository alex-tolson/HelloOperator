using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WiresFunction : MonoBehaviour, IPointerClickHandler//, IPointerMoveHandler, IPointerDownHandler, 
{
    private float _oldDistanceToJack;
    private float _currentDistanceToJack;
    private float _oldDistToPlaceHolder;
    private float _currentDistToPlaceHolder;
    private Vector3 _currentPos;

    [SerializeField] private GameObject _wireAnchor;
    [SerializeField] private GameObject _wireBeginAnchorPlaceHolder;
    [SerializeField] private GameObject _wireEnd;
    [SerializeField] private GameObject _wireEndAnchor;
    [SerializeField] private List <AnchorPlaceHolder> _anchorPlaceholderArray = new List<AnchorPlaceHolder>();
    [SerializeField] private List<Jack> _incomingJacks = new List<Jack>();
    [SerializeField] private Vector3 _wireOffset;

    private void OnEnable()
    {
        GameObject.Find("Call-Jacks-Container").GetComponentsInChildren<Jack>(_incomingJacks);
        GameObject.Find("SwitchboardPlaceHolders").GetComponentsInChildren<AnchorPlaceHolder>(_anchorPlaceholderArray);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("finding nearest jack");
        ConnectWireAtEnd();
    }

    public void ConnectWireAtEnd()
    {
        _currentDistanceToJack = 3;
        foreach (Jack jack in _incomingJacks)
        {
            _oldDistanceToJack = jack.FindNearestJack(_wireEnd.transform.position);

            if (_oldDistanceToJack < _currentDistanceToJack)
            {
                _currentDistanceToJack = _oldDistanceToJack;
                _wireEndAnchor.transform.position = jack.transform.position;
            }
        }
        _wireEnd.transform.position = _wireEndAnchor.transform.position + _wireOffset;
    }

    public void ConnectWireAtAnchor()
    {
        _currentDistToPlaceHolder = 1;
        foreach(AnchorPlaceHolder placeholder in _anchorPlaceholderArray)
        {
            _oldDistToPlaceHolder = placeholder.FindNearestPlaceHolder(_wireAnchor.transform.position);

            if (_oldDistToPlaceHolder < _currentDistToPlaceHolder)
            {
                _currentDistToPlaceHolder = _oldDistToPlaceHolder;
                _wireBeginAnchorPlaceHolder.transform.position = placeholder.transform.position;
            }
        }
        _wireAnchor.transform.position = _wireBeginAnchorPlaceHolder.transform.position;
   
    }
    //wire does not need to 
    //find the nearest placeholder.
    //just needs to move down -.03 on the y from the light
}

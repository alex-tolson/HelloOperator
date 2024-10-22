using UnityEngine;
using UnityEngine.EventSystems;
public class BellCall : MonoBehaviour, IPointerClickHandler
{
    private Switchboard2 _switchboard;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Bell clicked");
        _switchboard.InitiateCall();
    }


    // Start is called before the first frame update
    void Start()
    {
        _switchboard = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard == null)
        {
            Debug.LogError("BellCall::Switchboard is null");
        }
    }
}

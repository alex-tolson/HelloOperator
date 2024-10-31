using UnityEngine;
using UnityEngine.EventSystems;
public class BellCall : MonoBehaviour, IPointerClickHandler
{
    private Switchboard2 _switchboard2;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Bell clicked");
        //if bell clicked = false
        //then
        _switchboard2.InitiateCall();
        //else if bell clicked == true
        //message to resolve current call first
        //before taking another
    }


    // Start is called before the first frame update
    void Start()
    {
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("BellCall::Switchboard is null");
        }
    }
}

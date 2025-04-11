using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class BellCall : MonoBehaviour, IPointerClickHandler
{
    private Switchboard2 _switchboard2;
    private AudioManager _audioManager;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _switchboard2.CallComingThru();
        _audioManager.PlayBell();

    }


    // Start is called before the first frame update
    void Start()
    {
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("BellCall::Switchboard is null");
        }
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (_audioManager == null)
        {
            Debug.LogError("BellCall:: AudioManager is null");
            
        }

    }
}

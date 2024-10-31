using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CallManager : MonoBehaviour
{
    private Switchboard2 _switchboard2;
    [SerializeField] private TMP_Text _dialogue;
    private List<string> _dialogueChatter = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("CallManager::Switchboard2 is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Day1Call0()
    {
        if (_switchboard2.WhoIsAnswering().placementName == "Y1")
        {
            _dialogueChatter.Clear();
            _dialogueChatter.Add("Doris: Hello, this is Doris Minko.");
            _dialogueChatter.Add("Alice: Ms. Minko, it's Alice!.  Alice O'Connell");
            _dialogueChatter.Add("Doris: Yes, yes.  What's got your goat this morning?");
            _dialogueChatter.Add("Alice: I just had an awfully strange dream. I was hoping you could help me make sense of it?");
            _dialogueChatter.Add("Doris: At this hour?");
            _dialogueChatter.Add("Alice: I don't want to forget it! I can already feel it slipping away.");
            _dialogueChatter.Add("Doris: Alright, let's have it, then. You just talk; I'll take notes...");
            _dialogueChatter.Add("Alice: First, I knew I was dreaming.  ");
            _dialogueChatter.Add("Doris: It went like this:");
            _dialogueChatter.Add("Alice: It went like this:");
            _dialogueChatter.Add("Doris: It went like this:");
        }
        else if (_switchboard2.WhoIsAnswering().placementName == "Y4")
        {   //calling Leora Brown
            _dialogueChatter.Clear();
            _dialogueChatter.Add("Leora Brown at you service.  How can I help?");
        }
        else if (_switchboard2.WhoIsAnswering().placementName == "Y2")
        {
            //Calling Father Tallehasse Kinnison
            _dialogueChatter.Clear();
            _dialogueChatter.Add("77th Parish, Father Kinnison here.  How can I serve?");
        }
        else
        {

            //No answer
        }
    }

}

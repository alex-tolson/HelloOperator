using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _dialogue;
    private Switchboard2 _switchboard2;
    private string _choice;
    private CallManager _callManager;

    // Start is called before the first frame update
    void Start()
    {
        _callManager = GameObject.Find("Switchboard").GetComponent<CallManager>();
        if (_callManager == null)
        {
            Debug.LogError("DialogueManager::_callManager is null");
        }
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("DialogueManager::Switchboard2 is null");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //if it's day one, display dialog for call 1
    public void DisplayDialogue()
    {
        switch (_switchboard2.WhatDayItIs())
        {
            case 1:
                {
                    DialogueTextDay1();
                    break;
                }
            case 2:
                {
                    DialogueTextDay2();
                    break;
                }
            case 3:
                {
                    DialogueTextDay3();
                    break;
                }
            case 4:
                {
                    DialogueTextDay4();
                    break;
                }
            case 5:
                {
                    DialogueTextDay5();
                    break;
                }
            case 6:
                {
                    DialogueTextDay6();
                    break;
                }
            case 7:
                {
                    DialogueTextDay7();
                    break;
                }
            case 8:
                {
                    DialogueTextDay8();
                    break;
                }
            case 9:
                {
                    DialogueTextDay9();
                    break;
                }
        }
    }

    private void DialogueTextDay1()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "Hello, Operator!  Whew, I'm sorry!  I'm a bit flustered.  " +
                        "I just had the strangest dream.  I was lucid, but I could feel it in my bones." +
                        "I need a dream interpreter..."+ "\n\n" +"Give me Ms. Minko, Leora, or even Father Kinnison!" +
                        "\n\n"+"I just need somebody!";
                    //lock incoming toggle in up position until end of call
                    //check if the outgoingCaller is one of the 3 specified 
                    //if so, continue the conversation, if not
                    //give player a cue to try again.

                    break;
                }
            case 1:
                {
                    _dialogue.text = "wants to report a large, unleashed, big, black, hostile dog sighting";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "Wants to report bad tasting tap water";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "Noticed consistent and persistent bruising on Baas kid.";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "Want to speak with Walskin for an update on detailing Oliver Baas.";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "Wants to speak with local bank about accessing Treasury records from the city council.";
                    break;
                }
            case 6:
                {
                    _dialogue.text = "subject:";
                    break;
                }
            case 7:
                {
                    _dialogue.text = "Wants to talk about stopping mandatory overtime";
                    break;
                }
        }
    }

    private void DialogueTextDay2()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "Alice wants handyman to open an antique chest found in her crawl space.";
                    break;
                }
            case 1:
                {
                    _dialogue.text = "Calls about a compromised beam in the mines. ";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "Calls to say a local woman (Alice O’Connell) was admitted to the hospital " +
                        "for self-inflicted eye damage";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "Is looking for treatment for Alice O’Connell";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "Tells Zoe about he chest full of one eyed photo subjects";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "Wants to report the loose beam in the mines";
                    break;
                }
            case 6:
                {
                    _dialogue.text = "She gossips about Alice O’Connell, the chest " +
                        "full of pictures, and the eye gouging, and wants to set a hair appointment.";
                    break;
                }

        }
    }

    private void DialogueTextDay3()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "Informs him of the safety hazard tip that was anonymously reported and informs of an audit";
                    break;
                }
            case 1:
                {
                    _dialogue.text = "Calls to do a luck and prosperity ritual and is scheduling an appointment for tarot reading";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "Calls nonsecular practitioners for fringe medical treatment";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "Gossips that the local parish has been ordering weird stuff and sets a hair appointment";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "Wants a statement of expenditure for Church.  He has suspicions";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "Wants to warn Priest of the Prophecy of the Phoenix";
                    break;
                }
            case 6:
                {
                    if (_choice == "")
                    {
                        _dialogue.text = "Asks about the repair time line";
                    }
                    break;
                }
        }
    }

    private void DialogueTextDay4()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "Offers him a sale price on tarot readings like 6 for $100 instead of $25 a pop";
                    break;
                }
            case 1:
                {
                    _dialogue.text = "Calls to offer consultation to Oliver Jr. who confirms that he is bullied at school. ";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "Wants to discuss strange patrons he had this day: Patron 1 and patron 2 + Robert Templeton and Benjamin Smit";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "Confirms that Stephan escaped minimum security complex but would still be in the area.  ";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "Speaks cryptically and in circles about the Phoenix Proclamation";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "Chides Robert for taking advantage of clients hope.  Robert reveals he doesn’t believe in occult but relies on the faith of this clients.  ";
                    break;
                }
            case 6:
                {
                    _dialogue.text = "Confirms that the mine party is still set for several days out.  They work out the logistics of getting alcohol. Rumor of Hell’s gate is circulated.";
                    break;
                }
            case 7:
                {
                    _dialogue.text = "Wants to buy some time to keep the mine from closing… pending a payment";
                    break;
                }
            case 8:
                {
                    _dialogue.text = " Offers to complete the audit on his behalf.";
                    //_dialogue.text = " City Council President Aria Rodriguez to keep mines open to stimulate the economy.";
                    //_dialogue.text = " Bank manager to fund a loan from the City Council to the Mine Owner
                    //for repairs lest he releases her abusive ex from the Asylum.";
                    //

                    break;
                }
        }
    }

    private void DialogueTextDay5()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "Wants to report big black hostile dogs";
                    break;
                }
            case 1:
                {
                    _dialogue.text = "Wants Psyche Doctor to meet him at Porter house for evaluation and has Porter committed.";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "Wants to file complaint about water contamination.  " +
                        "Citing strange but similar tooth decay and gum rot in patients.";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "Calls to ask Librarian about occult instruments " +
                        "she’s found in several houses, including the church";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "she is absolutely livid that she had to retrieve her husband from the the asylum. Swears there’s a corrupt system";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "Wants an investigation into law enforcement books and Asylum Accounting books";
                    break;
                }
        }
    }

    private void DialogueTextDay6()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "wants Doris’ help researching the occult items found by Ophelia.  ";
                    break;
                }
            case 1:
                {
                    _dialogue.text = "Calls Parish to warn of shenanigans";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "She thinks she served the Asylum Escapee";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "finds occult items in dry cleaned Priest garb";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "Calls to question him about his absence at the parish";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "Theodore asks to be day labor inside the mines";
                    break;
                }
            case 6:
                {
                    _dialogue.text = "calls local parish to set appointment for confession";
                    break;
                }
            case 7:
                {
                    _dialogue.text = "Asks about occult items in Priest’s garb";
                    break;
                }
            case 8:
                {
                    _dialogue.text = "Books a room for 2 nights in utmost secrecy.";
                    break;
                }
        }
    }

    private void DialogueTextDay7()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "Talks about what their findings could mean";
                    break;
                }
            case 1:
                {
                    _dialogue.text = "Warn Father Tallehasse of Benjamin Smit’s denouncing of faith";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "Warns Father Smit that Father Kinnison must know or suspect about him";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "Orders a lantern oil and some other random items.  Reciting scripture about separating the wheat from the chaff";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "Calls to talk about strange findings in teeth, and similar gum decay in patients";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "Asks for help separating the wheat from the chaff.";
                    break;
                }
            case 6:
                {
                    _dialogue.text = "Asks for prayers after he got injured working in the mines.";
                    break;
                }
            case 7:
                {
                    _dialogue.text = "Calls to say the parish is on fire";
                    break;
                }
        }
    }

    private void DialogueTextDay8()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "";
                    break;
                }
            case 1:
                {
                    _dialogue.text = "";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "";
                    break;
                }
            case 6:
                {
                    _dialogue.text = "";
                    break;
                }
            case 7:
                {
                    _dialogue.text = "";
                    break;
                }
        }
    }

    private void DialogueTextDay9()
    {
        switch (_switchboard2.CallCount())
        {
            case 0:
                {
                    _dialogue.text = "";
                    break;
                }
            case 1:
                {
                    _dialogue.text = "";
                    break;
                }
            case 2:
                {
                    _dialogue.text = "";
                    break;
                }
            case 3:
                {
                    _dialogue.text = "";
                    break;
                }
            case 4:
                {
                    _dialogue.text = "";
                    break;
                }
            case 5:
                {
                    _dialogue.text = "";
                    break;
                }
            case 6:
                {
                    _dialogue.text = "";
                    break;
                }
            case 7:
                {
                    _dialogue.text = "";
                    break;
                }
        }
    }


}
    


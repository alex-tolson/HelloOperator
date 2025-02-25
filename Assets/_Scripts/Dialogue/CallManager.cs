using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CallManager : MonoBehaviour
{
    private Switchboard2 _switchboard2;
    private DialogueManager _dialogueManager;
    [SerializeField] private GameObject _callerPanel;
    [SerializeField] private GameObject _answererPanel;
    [SerializeField] private TMP_Text _dialogue;
    [SerializeField] private List<string> _dialogueChatter = new List<string>();
    private int _dialogueIteration = -1;
    private bool _call_2_5_Sanford;
    private bool _call_5_5_Walskin;
    private bool _call_5_6_Tauten;
    [SerializeField] private int ending1Count = 0;
    [SerializeField] private int ending2Count = 0;
    [SerializeField] private int ending4Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        _switchboard2 = GameObject.Find("Switchboard").GetComponent<Switchboard2>();
        if (_switchboard2 == null)
        {
            Debug.LogError("CallManager::Switchboard2 is null");
        }
        _dialogueManager = GameObject.Find("Canvas_WorldSpace").GetComponent<DialogueManager>();
        if (_dialogueManager == null)
        {
            Debug.LogError("CallManager::_dialogueManager is null");
        }
    }

    public bool Return_call_2_5_Sanford()
    {
        return _call_2_5_Sanford;
    }

    public bool Return_call_5_5_Walskin()
    {
        return _call_5_5_Walskin;
    }

    public bool Return_call_5_6_Tauten()
    {
        return _call_5_6_Tauten;
    }
    public string ReturnDialogueChatter()
    {
        _dialogueIteration++;
        if (_dialogueIteration < _dialogueChatter.Count)
        {
            return _dialogueChatter[_dialogueIteration];
        }
        else
        {
            _callerPanel.SetActive(false);
            return "";
        }
    }

    public void ResetDialogueIteration()
    {
        _dialogueIteration = -1;

    }

    //-----------------------Day 1----------------------

    public void Day1Call0() //Alice Calling
    {
        if (_switchboard2.WhoIsCalling().placementName == "A8") //Alice
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            _dialogueChatter.Add("Hello, Operator. I just had the most disturbing dream.  I " +
                "need it interpreted. Gimme Doris Minko, or Leora Brown. Heck, I'll even take " +
                "Father Kinnison.  Just give me somebody!");
        }
    }

    public void Day1Answer0()
    {
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y0": //calling Medium: Doris Minko
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    _dialogueChatter.Add("Doris: Hello, this is Doris Minko.");
                    _dialogueChatter.Add("Alice: Ms. Minko, it's Alice!.  Alice O'Connell");
                    _dialogueChatter.Add("Doris: Yes, yes.  What's got your goat this morning?");
                    _dialogueChatter.Add("Alice: I just had an awfully strange dream. " +
                        "I was hoping you could help me make sense of it?");
                    _dialogueChatter.Add("Doris: At this hour?");
                    _dialogueChatter.Add("Alice: I don't want to forget it! I can already feel it slipping away.");
                    _dialogueChatter.Add("Doris: Alright, let's have it, then. You just talk; I'll take notes...");
                    _dialogueChatter.Add("Alice: Firstly, immediately, I knew I was dreaming.  I was standing in front "
                        + " of a thing called the saver..  I was making an offering.  " +
                        "In one hand, there was an eyeball.  In the other " +
                        "I had something else.  I was to choose my offering but... but I didnt' choose. " +
                        "But I did.  I chose before I even " +
                        "thought it.  The Saver took the eye.  Then I could see everything. " +
                        " The town, the neighborhood where I live. " +
                        "My street... my house... then the door to the attic.");
                    _dialogueChatter.Add("Doris: Was the door open?");
                    _dialogueChatter.Add("Alice: No.  I woke up when I tried the handle.");
                    _dialogueChatter.Add("Doris:  Alright.  Very interesting.  We will let the tarot " +
                        "guide us during our next session.  Okay?" +
                        "Try and get some rest for now");
                    
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            case "Y3"://Calling Therapist: Leora Brown
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    _dialogueChatter.Add("Alice: Leora, it's Alice!");
                    _dialogueChatter.Add("Leora: Alice, What's happened.  You sound panicked.");
                    _dialogueChatter.Add("Alice: Yes.  I had a dream");
                    _dialogueChatter.Add("Leora: As we do.");
                    _dialogueChatter.Add("Alice: yeah... no.  This felt more real.  Like, I knew I was dreaming " +
                        "but I still couldn't act outside the events.  It's like they were " +
                        "scripted.  I was just playing my part but I could not stop playing my part.");
                    _dialogueChatter.Add("Leora: Do you want to tell me about the dream?  We'll unpack" +
                        " it during our next appointment.");
                    _dialogueChatter.Add("Alice: Okay.  I was standing in front of the Saver");
                    _dialogueChatter.Add("Leora: The Savior?");
                    _dialogueChatter.Add("Alice: No.  The Saver.  I was offering it something in exchange for something." +
                        "Something I don't know.  My hands were out.  In one hand, an eyeball.  I couldn't see" +
                        ".. what was in my other hand but it doesn't matter.  The Saver took the eyeball and " +
                        "from the moment, my mind opened." +
                        " I could see my bed, my house, the stree, the neighborhood where I lived... the mines.");
                    _dialogueChatter.Add("Leora: What next?");
                    _dialogueChatter.Add("Alice: I saw myself standing in front of the my attic door.  It was closed." +
                        "I woke up when I tried to open it.");
                    _dialogueChatter.Add("Okay.  I have a record.  Let's unpack this in the morning " +
                        "during our appointment, okay?  Try to rest.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();

                    break;
                }
            case "Y1"://Calling Priest: Father Tallehasse Kinnison
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    _dialogueChatter.Add("Kinnison: 77th Parish, Father Kinnison here.  How can I serve?");
                    _dialogueChatter.Add("Alice: Father, it's Alice. Alice O'Connell. I need to know about a " +
                        "dream I just had.");
                    _dialogueChatter.Add("Kinnison: Surely this can wait until morning?");
                    _dialogueChatter.Add("Alice: No, Father.  I don't want to lose any details.");
                    _dialogueChatter.Add("Kinnison: Well, did you write it down?");
                    _dialogueChatter.Add("Alice: No, but I want to tell you and then I'll write it " +
                        "down while it's all fresh" +
                        " So, I'm standing in front of something mechanical... I know it's called the " +
                        "Saver.  It wants me to choose. In one hand, I have an eyeball.  The other hand, " +
                        "I couldn't see what I was holding. But it didnt' matter, the Saver took the " +
                        "eyeball.  Then I could see... everything.  It started with me but then " +
                        "expanded out to where I could see my house, neighborhood, the mines, " +
                        "the town.  Then my vision zoomed back in on me and I'm standing at my attic door. " +
                        "It's closed and as soon as I try the handle, I wake up.");
                    _dialogueChatter.Add("Kinnison: And you believe this to be a premonition?");
                    _dialogueChatter.Add("Alice: I do, Father. I need to get into my attic and see what " +
                        "was being shown to me.");
                    _dialogueChatter.Add("Kinnison: See me tomorrow and we'll discuss more on your dream." +
                        " In the meantime, I'll do some research on the symbols you've mentioned.");
                    _dialogueChatter.Add("Thank you, Father.  Thank you.  Good night.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    public void Day1Call1() //Beatrice Calling
    {
        if (_switchboard2.WhoIsCalling().placementName == "C6") //Beatrice
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator?  I'm having a to-do with my vision.  I " +
                "don't know if these new glasses, or if I really did see something. " +
                "All I know is I have a real bad feeling and when I get these feelings, " +
                "they are usually not wrong.  Help me; I need to talk to someone.");
        }
    }

    public void Day1Answer1() //Beatrice Templeton calling
    {
        Debug.Log("Day 1, call 1");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X5"://calling Eye Doctor: Evelyn Porter
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    _dialogueChatter.Add("Evelyn: Thank you for calling Porterhouse Vision." +
                        " How may I help you?");
                    _dialogueChatter.Add("Beatrice: It's Beatrice. I think I'm seeing things");
                    _dialogueChatter.Add("Evelyn: That's great.  I'm glad the updated prescription " +
                        "is helping you. There may be a period of adjustment but once it passes...");
                    _dialogueChatter.Add("Beatrice: No, I mean, yesterday.  I got a sudden migraine spike and " +
                        "I saw a black dot in my vision.  I was doubled over in pain so I couldn't really " +
                        "tell if it was a dog, or my vision going out because of the migraine.");
                    _dialogueChatter.Add("Evelyn: That changes things.  Why don't you come in so we can rule out " +
                        "the prescription, okay?");
                    _dialogueChatter.Add("Beatrice: Thanks, Evelyn.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending2Count++;
                    break;
                }
            case "Y1"://calling Priest: Father Tallehasse Kinnison
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    _dialogueChatter.Add("Kinnison: 77th Parish: Father Tallehassee Kinnison at your service.");
                    _dialogueChatter.Add("Beatrice: Father Kinnison, I think I'm seeing things.");
                    _dialogueChatter.Add("Kinnison: What kinds of things, say you?");
                    _dialogueChatter.Add("Beatrice: Yesterday.  I got a sudden migraine spike and " +
                        "I saw a black dot in my vision.  I was doubled over in pain so I couldn't really " +
                        "tell if it was a dog, or my vision going out because of the migraine.");
                    _dialogueChatter.Add("Kinnison: What makes you think it was a dog?");
                    _dialogueChatter.Add("Beatrice:  Well I was outside, but I swear I heard something " +
                        "like a muffled or muted growling");
                    _dialogueChatter.Add("Kinnison: When did this happen?  About what time?");
                    _dialogueChatter.Add("Beatrice: It was about noon.  I left the gym early because of the migraine and " +
                        "I saw it as soon as I stepped out of my car.  I got a bad feeling about this Father.");
                    _dialogueChatter.Add("Kinnison: Well, I don't know what to make of it.  How are you feeling now.");
                    _dialogueChatter.Add("Beatrice: I'm fine but I've got a real bad feeling about everything right now");
                    _dialogueChatter.Add("Kinnison: Rest and take solice in the scriptures. That Revelations begins with the 4 " +
                        "horsemen... not dogs.  On the same note, you're  due for a confession, are you not?");
                    _dialogueChatter.Add("Beatrice: Yes Father.  I...");
                    _dialogueChatter.Add("Kinnison: Don't wait until the 11th hour, my child. ");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending2Count++;
                    break;
                }
            case "Y0"://calling Medium: Doris Minko
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    _dialogueChatter.Add("Doris: Hello, this is Doris Minko.");
                    _dialogueChatter.Add("Beatrice: Hi, Doris.  This is Beatrice.");
                    _dialogueChatter.Add("Doris: I know, Beatrice.  How can I help you?");
                    _dialogueChatter.Add("Beatrice: ...");
                    _dialogueChatter.Add("Doris: ... Caller ID.");
                    _dialogueChatter.Add("Beatrice: Oh! Right. Well, I'm calling because I think I saw " +
                        "something and I have a real bad feeling about it.");
                    _dialogueChatter.Add("Doris: Go on.");
                    _dialogueChatter.Add("Beatrice: Yesterday, I got a sudden migraine at the gym.  I went home " +
                        "early.  As I got out of my car, I experienced a migraine spike and was practically bent " +
                        "over in pain.  I saw a black dot in my vision and I thought it was a dog, but it may " +
                        "have been a blind spot in my vision from the migraine.  But I swear I heard muted growling.");
                    _dialogueChatter.Add("Doris: Do you recall other sounds being muted or just the growling " +
                        "you heard?");
                    _dialogueChatter.Add("Beatrice: Just the growling ");
                    _dialogueChatter.Add("Doris: What was the energy like?  What did you feel when you encountered this " +
                        "black dog.");
                    _dialogueChatter.Add("Beatrice: It felt ill.  Wrong.  I knew I was in pain, but I also felt absolute " +
                        "dread when I tried to focus on the dog.  I backed away from it, not turning my back on it, " +
                        "until I got to my door and made it inside.  But the feeling didn't go away.");
                    _dialogueChatter.Add("Doris: I'm not dog expert, but why would or what could cause a dog " +
                        "to mute it's growl?  It seems to me that perhaps you were having an auditory hallicination " +
                        "and it makes sense that it left you with a lingering feeling.");
                    _dialogueChatter.Add("Beatrice: Yeah. I suppose you're right.  It may have been due to the " +
                        "migraine.  Thanks for your time Doris.");
                    _dialogueChatter.Add("Doris: Anytime, Beatrice. ");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            case "Z1"://calling Sheriff: Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    _dialogueChatter.Add("Charlie: Sheriff Czerniak, what is it?");
                    _dialogueChatter.Add("Beatrice: Sheriff, it's Beatrice.");
                    _dialogueChatter.Add("Charlie: Alright, what is it... Beatrice?");
                    _dialogueChatter.Add("Beatrice: I think I saw an aggressive unleashed big black dog yesterday.");
                    _dialogueChatter.Add("Charlie: Okay. Why didn't you call me yesterday?");
                    _dialogueChatter.Add("Beatrice: I was nearly doubled over in pain from a sudden migraine that came on me. " +
                        "I had to rest.  I couldn't hardly put words together because of the pain. " +
                        "I almost couldn't tell it if was a blind spot from the migraine but " +
                        "everything about it felt wrong.  And I heard it growl. ");
                    _dialogueChatter.Add("Charlie: How big was the dog?");
                    _dialogueChatter.Add("Beatrice: It was, like, large but not as big as a Great Dane.");
                    _dialogueChatter.Add("Charlie: Any discernable features, color patterns? What did it sound like?");
                    _dialogueChatter.Add("Beatrice: I heard muted growling, real low.  I kept my distance from it.  I think it was " +
                        "all black");
                    _dialogueChatter.Add("Charlie: Where did you encounter this dog?");
                    _dialogueChatter.Add("Beatrice: Outside my residence.");
                    _dialogueChatter.Add("Charlie: And, are you on any medications?");
                    _dialogueChatter.Add("Beatrice: ... what does that have to do with anything?");
                    _dialogueChatter.Add("Charlie: ... Well, you said, it could have been a blind spot due to the migraine " +
                        "instead of a dog.I'm just trying to rule out anything I can.  After the still birth, " +
                        "did the Doc put you on any meds?  Please, Beatrice?");
                    _dialogueChatter.Add("Beatrice:  You know what? Forget it.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    public void Day1Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C7") //Lucas Porter calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator? Has the water tasted funny to you? " +
                "Well, you're not crazy. Something's wrong with the water in this town and " +
                "I want to make a report about it!");
        }
    }

    public void Day1Answer2() //Lucas Porter calling
    {
        Debug.Log("Day 1, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X7": //calling City Council Pres. Aria Rodriguez
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Aria: This is City Council President; Aria Rodriguez.  How may I serve you?");
                    _dialogueChatter.Add("Lucas: Hi, Aria.  This is Lucas Porter again.  Any word on that water sample that " +
                        "Thom took? It's been just over 8 weeks now and I've heard nothing back.  The tap water tastes " +
                        "like, like fish eggs! And it's only been getting worse. It's not good for the teeth; " +
                        "I'm telling you. At my last dentist appointment, they found absorption in my teeth.  That doesn't" +
                        " run in my family.  I brush and floss daily.  There's something wrong with the water in this " +
                        "place and they're trying to cover it up.  If nothing gets done about it, I'll be sending you " +
                        "my dentist bill!");
                    _dialogueChatter.Add("Aria: Look Lucas, we've been through this.  As soon as the water sample results " +
                        "come in, we'll mail out the evaluation.  Until then, we have no proof and a bunch of " +
                       "complaints about poor taste. Use a filter. And Blissville City Council will be in touch.  Good day.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending2Count++;
                    break;
                }
            case "Z1": //calling Sheriff: Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Lucas: Hi, Sheriff.  This is Lucas Porter again.  Any word on " +
                        "that water sample that Thom took? I have heard even a peep about it. The tap " +
                        "water has only been getting worse. It's not good for the teeth!");
                    _dialogueChatter.Add("Sheriff: Yes, Lucas, I don't have anything more I can tell you. " +
                        "You know as much as I do.  Thom took water samples; we sent them in.  Until we get " +
                        "the evaluation you might just have make do with a filter or purified drinking water.");
                    _dialogueChatter.Add("Lucas: Surely there's something you can do about it?");
                    _dialogueChatter.Add("Sheriff: Let me check:... No. There's nothing I can do at this time. In fact," +
                        "I gotta run.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    public void Day1Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z0") //Jonah Hennessy calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator? There's a senior at my school who I think is in trouble. " +
                "But he won't cooperate and tell me what's going on. I need someone to look into this for me.");
        }
    }
    public void Day1Answer3() //Jonah calling
    {
        Debug.Log("Day 1, call 3");

        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z9": //calling Teacher: Levi Johnson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Jonah: Hey, Levi.  It's Jonah.");
                    _dialogueChatter.Add("Levi: Right.  What's up?");
                    _dialogueChatter.Add("Jonah: I have a concern about...");
                    _dialogueChatter.Add("Levi: The Baas kid?");
                    _dialogueChatter.Add("Jonah: Oh god, I'm glad you said it first.");
                    _dialogueChatter.Add("Levi: I've been trying to get info out of him but he's tight-lipped.");
                    _dialogueChatter.Add("Jonah: I wouldn't been so concerned if he wasn't getting new bruises " +
                        "before the old ones have a chance to heal.");
                    _dialogueChatter.Add("Levi: I'll keep my eyes peeled for bullies.  It makes me sick, but I know " +
                        "they know how to not get caught.");
                    _dialogueChatter.Add("Jonah: You think it's bullies?");
                    _dialogueChatter.Add("Levi: You don't? We gotta start somewhere. Tell the Counselor if " +
                        "you want. I'll keep you posted on my end.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending2Count++;
                    break;
                }
            case "Z8": //calling Deputy: Willem Tauten
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Deputy Willem Tauten, what's on the menu for today?");
                    _dialogueChatter.Add("It's Jonah Hennessy.  I'm a teacher at the Blissville High School.");
                    _dialogueChatter.Add("Okay... what's this about?");
                    _dialogueChatter.Add("You know the Baas kid?");
                    _dialogueChatter.Add("Oliver Baas' kid.  He's the only one in town.");
                    _dialogueChatter.Add("He's been showing up to school with consistent and persistent bruising. " +
                        " I don't wanna point fingers but someone's gotta look into it. He won't talk to me. ");
                    _dialogueChatter.Add("I hear ya, loud and clear. I'll do a home check at the Baas' house. " +
                        "I can use the tap water as a cover.  I think everyone's left a complaint about it by now. ");
                    _dialogueChatter.Add("Thank you so much, Deputy Tauten.");
                    _dialogueChatter.Add("Thank you too.  We need more teachers like you.  If I have to open an " +
                        "investigation, I won't be able to disclose any information to you.  So if you don't hear " +
                        "from me, it's not personal. Um-kay?");
                    _dialogueChatter.Add("Okay.  Thanks.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            case "Z5": //calling House Doc: Eugene Franco
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Eugene: Doctor Eugene Franco, at your service?");
                    _dialogueChatter.Add("Jonah: Doc, it's Jonah. I'm calling because I've noticed that it seems " +
                        "everyday, lately, the Baas' kid comes to school with new bruises before the old " +
                        "ones can heal. He's withdrawn, shut down, won't talk about it either.");
                    _dialogueChatter.Add("Eugene: Let's not jump to conclusions. 17 year olds get into trouble and all " +
                        "kinds of trouble, at that. It's a sort of rite-of-passage.  It may not be abuse at home. " +
                        "And if so, what's changed that we're just now seeing evidence?");
                    _dialogueChatter.Add("Jonah: My job is to report.  I'm doing that.");
                    _dialogueChatter.Add("Eugene: I'll try to schedule a home visit to be thorough. It may be " +
                        "nothing... it may be something.");
                    _dialogueChatter.Add("Jonah: Keep me posted?");
                    _dialogueChatter.Add("Eugene: I'll let you know if I feel the need to involve the authorities.");
                    _dialogueChatter.Add("Jonah: Thanks, Doc.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    public void Day1Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z1") // Sheriff Czerniak calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, give me Deputy Harry Walskin. Please.");
        }
    }
    public void Day1Answer4()//Sheriff calling
    {
        Debug.Log("Day 1, call 4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z2": //Harry Walskin
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Harry: Deputy Walskin.");
                    _dialogueChatter.Add("Sheriff: Walskin, what have you got so far.");
                    _dialogueChatter.Add("So far, the subject has a busy but crime free day.");
                    _dialogueChatter.Add("Details, Walskin.  Gimme details...");
                    _dialogueChatter.Add("First he went to a City Council meeting.  That was probaby about 3 hours. " +
                        "I had eyes on him the whole time. He left from there and purchased about 10 scratch-" +
                        "off tickets.  Sat in his car and scratched them all. 1 hour.  He ate lunch, alone, downtown." +
                        "1 hour. Then he when to Robert Templeton's house for a good 3 hours.  Probaby trying to get lucky" +
                        "through more hoodoo voodoo or whatever he's peddling these days. I lost eyes on him " +
                        "when he enter the Templeton residence.");
                    _dialogueChatter.Add("Okay. Keep up the good work.  I'm working on getting the record to see " +
                        "if we get any leadss. You keep tailing him.");
                    _dialogueChatter.Add("You got it, Boss");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    public void Day1Call5()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z1") // Sheriff calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator. I need to speak to Blissville Bank?");

        }
    }

    public void Day1Answer5() //Sheriff calling Rose
    {
        Debug.Log("Day 1, call 5");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A5": ////calling Bank Manager: Rose Williams
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Rose: Thank you for calling Rose Williams: Blissville Account Manager. " +
                        "How may I help you.");
                    _dialogueChatter.Add("Sheriff: Rose, it's Charlie. Just givin' you a little update: " +
                        "The warrant is in the works.  Get those files ready.  And don't forget all I've " +
                        "done for you.");
                    _dialogueChatter.Add("Rose: That's unnecessary.  Produce the warrant " +
                        "and I can produce the files.  That's how it works.");
                    _dialogueChatter.Add("Sheriff: Just have those files ready.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    public void Day1Call6()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y8") // Yasmine Rivera calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, I need to speak with Father Smit");

        }
    }

    public void Day1Answer6() //Yasmine calling Smit
    {
        Debug.Log("Day 1, call 6");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y2": ////calling Priest: Father Benjamin Smit
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Smit: 77th Parish, Father Smit speaking.  Who is this?");
                    _dialogueChatter.Add("Yasmine: Yasmine.  You came by the other day but didn't knock on the door.");
                    _dialogueChatter.Add("Smit: You were watching?");
                    _dialogueChatter.Add("Yasmine: We're always watching. I saw you got into some light " +
                        "reading.  Find anything interesting?");
                    _dialogueChatter.Add("Smit: I'm... busy.");
                    _dialogueChatter.Add("Yasmine: Whatever you say... Father. You can always call me " +
                        "if you get lonely.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    public void Day1Call7()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A0") // Michael Walker calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hi, Operator? Connect me to Theodore Walker, please.");

        }
    }

    public void Day1Answer7() //Michael Walker calling Mine Supervisor: Theodore Walker
    {
        Debug.Log("Day 1, call 7");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A1": //calling Mine Supervisor: Theodore Walker
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Theo: Hello, it's Theo.");
                    _dialogueChatter.Add("Michael: Theo, it's me.  I've put off this call but I can't put it off any " +
                        "longer.");
                    _dialogueChatter.Add("Theo: Just get to it, Dad.");
                    _dialogueChatter.Add("Michael: We need to cut mandatory overtime. We're paying out but the miners " +
                        "are tired and the ends don't justify the means.  Plus, I've had several reports of needed " +
                        "repairs.  The last thing we want on our conscience is a cave-in.");
                    _dialogueChatter.Add("Theo: Are you asking me or are you telling me?");
                    _dialogueChatter.Add("Don't start with this again. I waited to see how you would handle the " +
                        "situation. But you've only doubled down.");
                    _dialogueChatter.Add("The mine is turning a profit for the first time in a decade.  We're not " +
                        "hemorraging money.");
                    _dialogueChatter.Add("Michael: But at what cost? It's not worth it. ");
                    _dialogueChatter.Add("Theo: You said you would let me handle it.");
                    _dialogueChatter.Add("Michael: Right, and you didn't.  So I'm stepping in.  Cancel the mandatory " +
                        "overtime.  And partition off the areas that need repairs. Pronto");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    //-----------------------Day 2----------------------

    public void Day2Call0()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A8") // Alice calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hi, I'm looking for a locksmith.  A handyman will do, if they've " +
                "got the right set of tools for the job.");
        }
    }

    public void Day2Answer0() //Alice Calling Carter
    {
        Debug.Log("Day 2, call 0");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "B8": //Calling Handyman: Carter Maddox
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Carter: Carter.");
                    _dialogueChatter.Add("Alice: Carter, it's Alice. Listen, I need to get into my attic.  I'm being " +
                        "drawn to this old antique chest that I'm sure is in there.  But I'm locked out." +
                        "I need you to get me into the attic and into that chest.  Can you do that?");
                    _dialogueChatter.Add("Carter: Of course. Me and Zoe don't charge much but for labor, you know that." +
                        "What time shall I come by?");
                    _dialogueChatter.Add("Alice: As soon as you can.  Thanks, Carter");
                    _dialogueChatter.Add("Carter: Not a problem.  I'll see you in an hour or so.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }
    public void Day2Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A7") // Frances Yareli calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator! How ya doing?  I need to speak with " +
                "Leonard Kinnison, please and thank ya kindly.");

        }

    }
    public void Day2Answer1() //Frances Yareli calling
    {
        Debug.Log("Day 2, call 1");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "C5": //Calling Miner: Leonard Kinnison 
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    _dialogueChatter.Add("Frances: Forgive me Father for I have sinned...");
                    _dialogueChatter.Add("Leonard: Wrong Kinnison.  This is Leonard.");
                    _dialogueChatter.Add("Frances: I know you are, you s.o.b. It's Frances!");
                    _dialogueChatter.Add("Leonard: Then what gives, Frances?");
                    _dialogueChatter.Add("Frances: All jokes aside, I've been thinking it awhile now. It's a " +
                        "matter of time till that dirt buries us alive.");
                    _dialogueChatter.Add("Leonard: Oh, I know");
                    _dialogueChatter.Add("Frances: Did you see that beam?");
                    _dialogueChatter.Add("Leonard: Yeah.");
                    _dialogueChatter.Add("Frances: I've already made a report to Sanford.  But I've been trying to " +
                        "get more people to pipe up. So, what do you say?");
                    _dialogueChatter.Add("Leonard: Yup.  I'll speak on it.");
                    _dialogueChatter.Add("Frances: I knew I could count on you. I've already said my piece so " +
                        " I'll leave you to it.  Bye.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }
    public void Day2Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A4") // Henry Thomas calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hi, Operator? Can you connect me to the Mitchell Motel?");

        }
    }
    public void Day2Answer2() //Henry calling Christina of the motel
    {
        Debug.Log("Day 2, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "B1"://Calling Motel Owner: Christina Mitchell
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Henry: Hey Chris.  It's Henry.");
                    _dialogueChatter.Add("Chrisina: You sound all shooken up.  What's going on?  Rough shift?");
                    _dialogueChatter.Add("Henry: You could say that.  A local woman was just admitted for " +
                        "self-inflicted eye damage.  She ripped it right out.  Carter brought her in... he " +
                        "saw the whole thing.");
                    _dialogueChatter.Add("Chrisina: My god, why would anyone go and do a thing like that?");
                    _dialogueChatter.Add("Henry: She kept saying she was fine and that she could see. " +
                        "But there was just a hole in her head where the eye should have been.  And still " +
                        "I felt her eyes looking right through me.");
                    _dialogueChatter.Add("Christina: Who is this woman?");
                    _dialogueChatter.Add("Henry: I'm not supposed to say, but it's Alice.  You know, O'Connell?");
                    _dialogueChatter.Add("Chrisina: Right, she just inherited the big old farm.");
                    _dialogueChatter.Add("Henry: Yeah. Carter said he was there, helping her get into the attic " +
                        "but then he broke down and clammed up.  We couldn't get him  to tell us what " +
                        "happened.");
                    _dialogueChatter.Add("Chrisina: I remember old stories told about that farm... " +
                        "nothing good. Hmm, maybe I'll drop by to check on you both. ");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }
    public void Day2Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "X3") // Dr. Miles Hanson calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hi, Operator.  This is Docter Miles Hanson. I'm looking for a doctor that " +
                "can either help with ocular damage or mental health? Do you have either in your roster?");

        }
    }
    public void Day2Answer3() //Doctor miles calling Leora
    {
        Debug.Log("Day 2, call 3");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y3": //Calling Therapist: Leora Brown
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Leora: This is the office of Doctor Leora Brown?");
                    _dialogueChatter.Add("Miles: This is Doctor Miles Hanson from Blissville County Hospital." +
                        "Your reputation precedes you as we have never met.  ");
                    _dialogueChatter.Add("Leora: Alright Doctor, how can I help you?");
                    _dialogueChatter.Add("Miles: I have a patient who was admitted today for a self-inflicted injury to the " +
                        "ocular cavity.  She attacked and ripped out her own eye. She hasn't been making much sense and all the " +
                        "information we have received is from the man that brought her to the Emergency Room.  He witnessed the " +
                        "the occurrence.");
                    _dialogueChatter.Add("Leora: I'm open to new patients.");
                    _dialogueChatter.Add("Miles: Yes, I saw you on the roster of floating doctors and thought maybe you might be " +
                        "able to get through to her as you're also a psychiatrist.");
                    _dialogueChatter.Add("Leora: That's correct. Is there a particular time slot you have available for me " +
                        "to visit with the patient?");
                    _dialogueChatter.Add("Miles: She's sedated for now.  It will wear off in about 3 hours at which she will " +
                        "wake up when ready.  I would like you there.  You're welcome to come in early to review her case.");
                    _dialogueChatter.Add("Leora: Will do.  Expect me in about 90 minutes or so");
                    _dialogueChatter.Add("Miles: Thank you so much Doctor.  I'll have the case ready.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            case "X5": //Calling Eye Doctor: Evelyn Porter
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Evelyn: Porterhouse Ophthalmology, Doctor Porter.");
                    _dialogueChatter.Add("Miles: Hi, this is Doctor Miles Hanson from Blissville County. I have an unusual " +
                        "case of a patient damaging their ocular cavity and eye.  I thought if anyone could salvage " +
                        "the situation, it's you.");
                    _dialogueChatter.Add("Evelyn: Thank you.  I'll come by right away to see what, if anything, " +
                        "can be done.");
                    _dialogueChatter.Add("Miles: Thanks.  I'll have a tech ready with the case files upon your arrival.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending2Count++;
                    break;
                }
            case "X1": //Psyche Doctor: Patrick Walskin
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Patrick: Patrick Walskin at your service");
                    _dialogueChatter.Add("Miles: Doctor Walskin, it's Doctor Miles Hanson from Blissville Country Hospital. " +
                        "It's an unusual case of self-harm and frankly, we're just not equipped to help the patient. " +
                        "So I called you.");
                    _dialogueChatter.Add("Patrick: Okay.  What's the status of the Patient now?");
                    _dialogueChatter.Add("Miles: Sedated.  She's not coherent but perhaps when the sedation wears off, you " +
                        "can have a conversation with her to see what our next steps should be.");
                    _dialogueChatter.Add("Patrick: I agree.  I need to get inside her head to see what she sees and for that " +
                        "to happen, first, she needs to be lucid.");
                    _dialogueChatter.Add("Miles: So, I'll give you a call when the patient is up?");
                    _dialogueChatter.Add("Patrick: Sure, I'll take it from there.");
                    _dialogueChatter.Add("Miles: Thank you Doctor.");
                    _dialogueChatter.Add("Patrick: Thank you.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day2Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "B8") // Carter calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("It's been a day, Operator.  Please transfer me to Zoe Maddox.");

        }
    }
    public void Day2Answer4() //Carter calling Zoe
    {
        Debug.Log("Day 2, call 4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "B2": //Calling Handyman: Zoe Maddox
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Zoe: Zoe Carter, here.");
                    _dialogueChatter.Add("Carter: Zoe, it's Carter.  I'm at the County Hospital.");
                    _dialogueChatter.Add("Zoe: Oh god! Are you alright? What happened?  Are you hurt?");
                    _dialogueChatter.Add("Carter: No, babe.  But something happened to Alice.  She... " +
                        "plucked out her own eye! She might have done the other one if I hadn't stopped her!");
                    _dialogueChatter.Add("Zoe: What do you mean?  You mean, she gouged it out?");
                    _dialogueChatter.Add("Carter: Yes, babe, that's exactly what I mean!");
                    _dialogueChatter.Add("Zoe: Why would anyone...?");
                    _dialogueChatter.Add("Carter: I'll tell it to you from the start, but I just " +
                        "wanted to check in so you'd know. I've been questioned over and over.  I think they're " +
                        "about to let me go.");
                    _dialogueChatter.Add("Zoe: They don't think you did it, do they?");
                    _dialogueChatter.Add("Carter: No. She was holding her own eye in her " +
                        "hand when I brought her in. It's just so hard to believe. " +
                        "I'll fill you in when I get home.  See you soon.");
                    _dialogueChatter.Add("Zoe: Baby, I'm so sorry.  I'll see you when you get here.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                }
                break;
        
        default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day2Call5()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C5") // LEONARD calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator. I'm looking to make a report for unsafe mining conditions" +
                "down at the local mines?");

        }
    }
    public void Day2Answer5() //Leonard calling Theo
    {
        Debug.Log("Day 2, call 5");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A1": //Calling Mine Supervisor: Theodore Walker
                {
                    ResetDialogueIteration();
                    _call_2_5_Sanford = false;

                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Theo: It's Theo. Speak.");
                    _dialogueChatter.Add("Leonard: Hey, there.  Theo.  It's Leonard Kinnison.");
                    _dialogueChatter.Add("Theo: Hey, what can I do for you?");
                    _dialogueChatter.Add("Leonard: I'll just spill the beans.  No one is too keen on this mandatory " +
                        "overtime, especially with that loose beam in tunnel C7 and A4 looming about. " +
                        "We've written letters, called and left voicemails cause no one is ever at the phone, " +
                        "and yet, nothing's been done. So I'm glad I caught you at a good time.  But I've gotta " +
                        "pull out for safety reasons.  Me and a few of the other guys.  We can't work like this.");
                    _dialogueChatter.Add("Theo: Whoa, now. Let's not let our emotions do the talking. I have... tunnels " +
                        "C7, A4, B3, G66 on the list of repairs. We're actually partitioning off those tunnels while " +
                        "repairs to the support beams are being installed.");
                    _dialogueChatter.Add("Leonard: Well, call us when it's done.  Until then, I want no part of the mines. " +
                        "Too dangerous.");
                    _dialogueChatter.Add("Theo: I can understand your hesitation. But...");
                    _dialogueChatter.Add("Leonard: Call us when the repairs are done.  Until then, it's too dangerous.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;

                    break;
                }
            case "Y9"://Calling Code Enforcement: Thomas Sanford
                {
                    ResetDialogueIteration();
                    _call_2_5_Sanford = true;

                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Code Enforcement Officer, Thom Sanford here.");
                    _dialogueChatter.Add("Leonard Kinnison.");
                    _dialogueChatter.Add("Hiya Leonard, what can I do for ya?");
                    _dialogueChatter.Add("I hate this, but we've been writing, calling and leaving voicemails, asking " +
                        "for weeks for some of the beams in the mines to get repaired.  I know it's gonna cost " +
                        "an arm and a leg but hell, they've been cracking the whip pretty hard.  I'm sure they'll be " +
                        "fine.  But we won't be... if a cave in happens.  So I'm reporting them.  I've got C7, A4, B3 " +
                        "and G66 either broken, rotted, or banged up in some way.  So please, do something.  These " +
                        "mines... they can't... they won't be the death of me.");
                    _dialogueChatter.Add("I hear you, Leonard. Loud and Clear.  I've got an inspection of the mine " +
                        "coming up and you say C7, A4, B3, and G66? I'll be on the lookout. Look, I know how you " +
                        "feel. This is many folks' livelihood. And sometimes, the hard thing and the right " +
                        "thing is the same thing. ");
                    _dialogueChatter.Add("Ain't it so?");
                    _dialogueChatter.Add("Eyup. So do what you gotta do.  I'll be in that mine within a week or so.");
                    _dialogueChatter.Add("Thanks, Thom.");
                    _dialogueChatter.Add("You betcha.");
                _switchboard2.AdvanceCallCount();
                _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }
    public void Day2Call6()
    {
        if (_switchboard2.WhoIsCalling().placementName == "B2") // ZOE calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator? Please connect me to Ms. Tutsie Pattinson.");

        }
    }
    public void Day2Answer6() //Zoe calling Tulip
    {
        Debug.Log("Day 2, call 6");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "C9": //Hair Stylist: Tulip Pattinson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Tulip: It's Tulip, honey.");
                    _dialogueChatter.Add("Zoe: It's me...");
                    _dialogueChatter.Add("Tulip: Zoe! All I've heard are snippets here and there, but I gotta hear it from " +
                        "you! So what really happened?");
                    _dialogueChatter.Add("Zoe: Carter called me all shook up. He looked even worse when he got home!" +
                        "This morning, he wakes up at the crack of dawn to meet Alice. She has him jimmy the lock " +
                        "to the attic in that old house.  She says she hadn't been in there since Jeffers died " +
                        "and left it to her.");
                    _dialogueChatter.Add("Tulip: Giiiirl! go on.");
                    _dialogueChatter.Add("Zoe: There, inside the attic, is this ornate beautiful inlaid bronze " +
                        "chest.  She goes to it like she knew it was there but she said she'd only seen " +
                        "it in her dreams.  So he jimmies the lock to the chest.  Inside are pictures " +
                        "of people she'd never met but...");
                    _dialogueChatter.Add("Tulip: Girl! What?!");
                    _dialogueChatter.Add("Zoe: BUT... they're all missing one eye.  Every. Single. Picture. " +
                        "They're missing the left eye.  Carter said he got chills from looking at the " +
                        "pictures and when he looked up, Alice just plucked her own eye out like plucking " +
                        "an apple from an apple tree.");
                    _dialogueChatter.Add("Tulip: Girl, nooo");
                    _dialogueChatter.Add("Zoe: He screamed and got her to the hospital as so as he could. Blood " +
                        "running down her face. He said he'll never forget the way she smiled, right before they took" +
                        "her back to the Emergency Room. Blood got in her mouth, spilling over her lips.");
                    _dialogueChatter.Add("Tulip: Girl, nooo");
                    _dialogueChatter.Add("Zoe: Girl, yes.  That's what he said.  Anywho, what's your schedule look like?");
                    _dialogueChatter.Add("Tulip: How about tomorrow at 2?");
                    _dialogueChatter.Add("Zoe: I'm just doing the usual with subtle highlights this time.");
                    _dialogueChatter.Add("Tulip: You got it.  See ya then, hun.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }
    public void Day2Call7()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y2") // Smit calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator. This is Father Smit of the 77th Parish.  " +
                "I need to speak with young Oliver Baas Jr.");

        }
    }
    public void Day2Answer7() //Smit calling Ollie Jr.
    {
        Debug.Log("Day 2, call 7");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "B4": //Son: Ollie Jr.
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("H-hello?");
                    _dialogueChatter.Add("This is Father Smit from 77th Parish. Is this Oliver Baas Jr.");
                    _dialogueChatter.Add("Yes, Father.");
                    _dialogueChatter.Add("I'm calling on you because you've been observed with bruises." +
                        "Bruises upon bruises. What's going on, son?");
                    _dialogueChatter.Add("It's nothing, Father.");
                    _dialogueChatter.Add("If you wish to endure it in silence, you may.  But you need not." +
                        "Now, is everything okay at home?");
                    _dialogueChatter.Add("It's not my dad. Just some jerks at school. But everything I " +
                        "do just makes it worse. I've told the teacher; I've told the principle. I've told " +
                        "my dad.");
                    _dialogueChatter.Add("But they do nothing?");
                    _dialogueChatter.Add("Yes. I mean, no, Father.");
                    _dialogueChatter.Add("Are you familiar with the story of Samson?");
                    _dialogueChatter.Add("Yes, Father. He was dedicated to the church and then he was betrayed, " +
                        "his long hair cut and his strength was gone when his hair was cut.");
                    _dialogueChatter.Add("Do you remember how his story ended?");
                    _dialogueChatter.Add("Not really.");
                    _dialogueChatter.Add("Well, I'll tell you, he prayed and received his strength one last " +
                        "time and used it to vanquish his enemies");
                    _dialogueChatter.Add("Why are you telling me this");
                    _dialogueChatter.Add("Because our God is a vengeful God. Where do these bullies hang out?");
                    _dialogueChatter.Add("I don't know but I did hear there was a party happening in the " +
                        "mines... several days from now.");
                    _dialogueChatter.Add("Hmm, maybe we can use this to our advantage. Until then, have faith " +
                        "and be patient."); 
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                     
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    //-----------------------Day 3----------------------

    public void Day3Call0()
    {
        if (_call_2_5_Sanford == true)
        {
            if (_switchboard2.WhoIsCalling().placementName == "Y9") // THOMAS SANFORD calling
            {
                ResetDialogueIteration();
                _dialogueChatter.Clear();
                //_dialogueChatter.Add("");
                _dialogueChatter.Add("Thomas Sanford, Code Enforcement and Internal Affairs here. " +
                    "I need to speak with Michael Walker, please.");

            }
        }
        else
        {
            if (_switchboard2.WhoIsCalling().placementName == "A1") // THEO WALKER calling
            {
                ResetDialogueIteration();
                _dialogueChatter.Clear();
                //_dialogueChatter.Add("");
                _dialogueChatter.Add("Operator, please connect me to Michael Walker.");

            }
        }
    }

    public void Day3Answer0()
    {
        Debug.Log("Day 3, call 0");
        if (_call_2_5_Sanford == true) //Thomas Sanford calling Michael
        {
            switch (_switchboard2.WhoIsAnswering().placementName)
            {
                case "A0": //Calling Mine Owner: Michael Walker
                    {
                        ResetDialogueIteration();
                        _dialogueChatter.Clear();
                        //_dialogueChatter.Add("");
                        _dialogueChatter.Add("Michael: Eyup, this is Michael Walker.");
                        _dialogueChatter.Add("Thomas: Mr. Walker, this is Thomas Sanford, Blissville Code Enforecement.");
                        _dialogueChatter.Add("Michael: At your service...");
                        _dialogueChatter.Add("Thomas: Thank you.  I'm calling to schedule your quarterly audit.");
                        _dialogueChatter.Add("Michael: Ah, right then. Let's say... 5 Business days? We're " +
                            "wrapping up some repairs.");
                        _dialogueChatter.Add("Thomas: Alright then, 5 business days.  The hour will undisclosed, " +
                            "determined by me.");
                        _dialogueChatter.Add("Michael: Very good. Thank you.");
                        _dialogueChatter.Add("Thomas: Thank you as well.");
                        _switchboard2.AdvanceCallCount();
                        _switchboard2.CallIsComplete();

                        break;
                    }
                default:
                    {
                        Debug.Log("There was no answer.");
                        //No answer
                        break;
                    }
            }
        }
        else //Theo Calling Michael
        {
            switch (_switchboard2.WhoIsAnswering().placementName)
            {
                case "A0": //Calling Mine Owner: Michael Walker
                    {
                        ResetDialogueIteration();
                        _dialogueChatter.Clear();
                        //_dialogueChatter.Add("");
                        _dialogueChatter.Add("Michael: Eyup, this is Michael Walker.");
                        _dialogueChatter.Add("Theo: Dad, it's me. Leonard called and said he and a bunch more " +
                            "were gonna pull out!");
                        _dialogueChatter.Add("Michael: Well, what did you say to him?");
                        _dialogueChatter.Add("Theo: Nothing. He called talking about some of the beams, in tunnels " +
                            "we don't even use, were going bad. We really don't even use those tunnels.  He says" +
                            "it's too dangerous and to call them when it's fixed.");
                        _dialogueChatter.Add("Michael: Arlight.  Well, it seems our next course of action is to get " +
                            "those beams fixed. If we want to stay in the black this quarter.");
                        _dialogueChatter.Add("Theo: You don't get it. It's not about the beams. They can't stand " +
                            "that I tell'em what to do.");
                        _dialogueChatter.Add("Michael: Theo, you've got to show them that you can lead before they " +
                            "will follow you.");
                        _dialogueChatter.Add("Theo: That's what I'm doing.");
                        _dialogueChatter.Add("Michael: No.  That's what you think you're doing. You've got to " +
                            "connect with these people.  This mine won't be around for much longer.  I want " +
                            "to squeeze profit out of it too, but you're making a case for an early " +
                            "closure and that benefits nobody.");
                        _dialogueChatter.Add("Theo: So what do I do?");
                        _dialogueChatter.Add("Michael: Do the next right thing.  Fix the beams.");
                        _switchboard2.AdvanceCallCount();
                        _switchboard2.CallIsComplete();
                        break;
                    }
                default:
                    {
                        Debug.Log("There was no answer.");
                        //No answer
                        break;
                    }
            }
        }
    }

    public void Day3Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "X4") // OLIVER BAAS calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hey there, I'm trying to reach a Mr Robert Templeton. My luck has run dry " +
                "at the wrong time.");

        }
    }

    public void Day3Answer1() //Oliver Baas calling Robert Templeton
    {
        Debug.Log("Day 3, call 1");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A5": //Calling Entertainer: Robert Templeton
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Rob, it's Ollie.  I was on a winning streak but... " +
                        "I just... I need to do another ritual. I know it's kinda soon, but " +
                        "look at it like this, at this rate, I'll be putting your kid through " +
                        "college.");
                    _dialogueChatter.Add("...");
                    _dialogueChatter.Add("Aw jeez, Rob.  I didn't mean it like that. I'm an idiot!");
                    _dialogueChatter.Add("Just forget it. Ollie.  Negative self-speak like that can hinder" +
                        "the success that is owed you.  So come on by, we'll do a luck and prosperity " +
                        "ritual and let's get that tarot reading in there as well.");
                    _dialogueChatter.Add("Thanks.  And again, I'm so sorry. Okay. Bye.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day3Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C5") // LEONARD calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hey dere, youse got any class clowns dere? He's the only clown in town.");

        }
    }

    public void Day3Answer2() //Leo calling Frances.
    {
        Debug.Log("Day 3, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A7": 
                {
                    //Runs into Smit in the Mines.  Smit says he was cleansing spirts

                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("You'll never guess who I just ran into while leaving work.");
                    _dialogueChatter.Add("Jesus.");
                    _dialogueChatter.Add("Close enough. I nearly knocked heads with Father Smit");
                    _dialogueChatter.Add("The Father? What was he doing in the mines?");
                    _dialogueChatter.Add("He said he was doing a cleansing.");
                    _dialogueChatter.Add("Oh?");
                    _dialogueChatter.Add("From the looks of it, he was doing a helluva job. He was " +
                        "covered in soot and had candles, incense, the whole shebang.");
                    _dialogueChatter.Add("It had been feeling more and more uneasy in there.");
                    _dialogueChatter.Add("Yeah, me and some of the other guys noticed too.");
                    _dialogueChatter.Add("Well, did it feel any better?.");
                    _dialogueChatter.Add("Not really...");
                    _dialogueChatter.Add("Lucky us, huh?  Gotta run.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day3Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A3") // LUANNE calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator? Can you please transfer me to Ms. Pattinson?");

        }
    }

    public void Day3Answer3() //Luanne Bourne calling Tulip
    {
        Debug.Log("Day 3, call 3");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "C9": //Calling Hair Stylist: Tulip Pattinson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Tulip: It's Tulip, honey.");
                    _dialogueChatter.Add("Luanne: Tulip, it's Luanne.  I need a hair appointment. ");
                    _dialogueChatter.Add("Tulip: ... Girl.");
                    _dialogueChatter.Add("Luanne: Alright... the local parish has been ordering some weird stuff " +
                        "lately. I don't know who's doing it but it doesn't feel right.  I mean, I'm " +
                        "protestant anyways but I still know some stuff cause my mom was raised Catholic...");
                    _dialogueChatter.Add("Tulip: Girl.");
                    _dialogueChatter.Add("Luanne: Right, so I was thinking I was crazy, cause one order had things " +
                        "like crystals, gemstones, and candles.  But this order has more candles, vials, " +
                        "and tarot cards. And I'm thinking... that ain't Catholic.  That ain't Catholic at all. ");
                    _dialogueChatter.Add("Tulip: oooooh girl, the plot thickens. See me today at 11am?");
                    _dialogueChatter.Add("Luanne: That's perfect. I can fill you in on the rest.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day3Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y1") // FATHER KINNISON calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Blissville Bank please and peace be unto you. ");

        }
    }

    public void Day3Answer4() //Father Kinnision calling Rose
    {
        Debug.Log("Day 3, call 4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A5": //Calling Account Manager: Rose Williams
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Rose: Thank you for calling Rose Williams: Blissville Account Manager. " +
                        "How may I help you.");
                    _dialogueChatter.Add("Father Kinnison: Rose, it's Father Tallehasse Kinnison.");
                    _dialogueChatter.Add("Rose: Hi, Father Kinnison.  How may I assist you today.");
                    _dialogueChatter.Add("Father Kinnison: I was going over the books and a few extra debits " +
                        "caught my eye.  I was wondering if you had any more info on them.");
                    _dialogueChatter.Add("Rose: Let's take a look.");
                    _dialogueChatter.Add("Father Kinnison: So the purchases in question are from last week. The " +
                        "company says name reads as Alone in the Dark?  Can you see anymore details about what " +
                        "was purchased? ");
                    _dialogueChatter.Add("Rose: No. It seems it was a recurring purchase for different amounts. " +
                        "The delivery was sent to the General Store in town. It was likely ordered there." +
                        "They probably have a manifest of ordered items they can pull up.");
                    _dialogueChatter.Add("Father Kinnison: Alright, Rose. Thanks for your help.");
                    _dialogueChatter.Add("Rose: Anytime, Mr. Kinnison.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day3Call5()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y5") // XENA PATTINSON calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("I need to speak to the Father. The local Priest at 77th Parish in town? ");

        }
    }

    public void Day3Answer5() //Xena Pattinson calling Kinnison/Smit
    {
        Debug.Log("Day 3, call 5");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y2": //Calling Priest: Tallehasse Kinnison
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Father Kinnison of the 77th Parish.  How may I serve you?");
                    _dialogueChatter.Add("...");
                    _dialogueChatter.Add("Hello? ..."); 
                    _dialogueChatter.Add("I don't know who you are or why you keep calling but You are welcome here " +
                        "under the sacrifice of the Lamb of God.");
                    _dialogueChatter.Add("Father... there's a prophecy...");
                    _dialogueChatter.Add("There are many prophecies.");
                    _dialogueChatter.Add("Yes, but the Phoenix, its remnants are converging, carrying out the " +
                        "prophecies in this very town.");
                    _dialogueChatter.Add("That may be true... but the blood of Jesus Christ covers me and all" +
                        "that are his.  We will be fine.");
                    _dialogueChatter.Add("Father!");
                    _dialogueChatter.Add("Have faith in Jesus Christ and let it be so.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            case "Y3": //Calling Priest: Benjamin Smit
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Smit: Father Smit of the 77th Parish.  How may I serve you?");
                    _dialogueChatter.Add("Xena: ...");
                    _dialogueChatter.Add("Smit: You again.");
                    _dialogueChatter.Add("Xena: The Prophecy of the Phoenix is revealing itself to come to pass.");
                    _dialogueChatter.Add("Smit: Is that so?  So who are you, then?");
                    _dialogueChatter.Add("Xena: I am a merely a servant...");
                    _dialogueChatter.Add("Smit: Aren't we all? And your purpose?");
                    _dialogueChatter.Add("Xena: ...");
                    _dialogueChatter.Add("Smit: Couldn't God's glory be shown if the prophecy did come to pass? " +
                        "The number 1 barrier to faith... is fear.  And yet fear breeds faith, does it not?");
                    _dialogueChatter.Add("Xena: ....");
                    _dialogueChatter.Add("Smit: ...");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day3Call6()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y3") // LEORA BROWN calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator? Please connect me to Robert Templeton.");

        }
    }

    public void Day3Answer6() //Leora calling Templetons
    {
        Debug.Log("Day 3, call 6");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y4": //Entertainer: Robert Templeton
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Leora: Hi, this Leora. Brown. Is this Rob or Beatrice?");
                    _dialogueChatter.Add("Robert: Hey Leora. My wife is in the kitchen.");
                    _dialogueChatter.Add("Leora: You and Beatrice didn't show up for our session " +
                        "this morning.  And you didn't call to say you couldn't make it so I thought " +
                        "I'd reach out.");
                    _dialogueChatter.Add("Robert: Yeah, sorry.");
                    _dialogueChatter.Add("Leora: It's not like either of you to no call no show. Did you " +
                        "want to reschedule your grief counseling? ");
                    _dialogueChatter.Add("Robert: No. We'll just stick to the schedule and show for the next " +
                        "appointment. Again, something came up and we just forgot to call. Sorry.");
                    _dialogueChatter.Add("Leora: Very well. See you next week.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }


    //-----------------------Day 4----------------------

    public void Day4Call0()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y4") //ROB TEMPLETON calling
        { 
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hiya Operator, I need to speak with Oliver Baas Sr. please. ");

        }
    }

    public void Day4Answer0() //Rob calling Oliver Sr.
    {
        Debug.Log("Day 4, call 0");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X4": //Calling Oliver Baas
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Hey Oliver, it's Rob.");
                    _dialogueChatter.Add("Rob!  My main man.  That ritual really worked like a charm. I'm on the up " +
                        "and up again.  I can see it.  I can feel it!");
                    _dialogueChatter.Add("Good!  Good!  We want to channel that energy.  Manifest our destiny! " +
                        "And also, I got a deal on rune readings plus the works! 6 for $200 instead of $50 a reading?");
                    _dialogueChatter.Add("Sold!");
                    _dialogueChatter.Add("Keep that momemtumn going.  Keep channeling that faith.");
                    _dialogueChatter.Add("Alright Rob.  I will.  I gotta run.  City council stuff, you know how it is.");
                    _dialogueChatter.Add("Alright, Ollie.  Come on by any time tomorrow for your first reading and we can " +
                        "schedule the rest.  Spread them out every couple weeks or so.");
                    _dialogueChatter.Add("You got it. Bye");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();

                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day4Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y1") // KINNISON calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Peace be unto you, Operator. I hope the day is treating you well. I'd like to " +
                "speak to Oliver Baas Jr. ");

        }
    }

    public void Day4Answer1() //Kinnison calling OBJ
    {
        Debug.Log("Day 4, call 1");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "B4": //Calling Oliver Baas Jr.
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Good afternoon.  I'm looking for Oliver Baas.  This is Father Kinnison" +
                        " of the 77th Parish.");
                    _dialogueChatter.Add("uh, my dad isn't in.");
                    _dialogueChatter.Add("Actually, I'm lookin for Jr.  That's you, right?");
                    _dialogueChatter.Add("Yeah. What, uh, what do you want?");
                    _dialogueChatter.Add("Someone reached out to me about you. They said you've been showing up" +
                        " at school with new bruises before the old one have had a chance to heal.");
                    _dialogueChatter.Add("*groan*");
                    _dialogueChatter.Add("Is everything alright at home, son?");
                    _dialogueChatter.Add("Look, it's just some jerks from school. They'll push me from behind, " +
                        "into lockers. A couple months till graduation and I'm outta this hellhole.");
                    _dialogueChatter.Add("But we need to keep you in good shape now. If the school won't " +
                        "talk to their parents I will.  Can you give me their names?");
                    _dialogueChatter.Add("Look Father, I'm not looking to make things any worse for myself." +
                        " I can hang on a few more months till I graduate.");
                    _dialogueChatter.Add("You not alone in this.");
                    _dialogueChatter.Add("I appreciate the concern Father, but I'll pass. Can I go, now?");
                    _dialogueChatter.Add("Yeah. I'll let you go.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day4Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A2") // AMOS SAXTON calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Good day, Operator. I have a dire need to speak with the Sheriff. And if you " +
                "hear from one Alice O'Connell, do let the Sheriff know, won't you? ");

        }
    }
    public void Day4Answer2() //Amos Saxton calling Sheriff
    {
        Debug.Log("Day 4, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z1": //Calling Sheriff: Charles Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Sheriff Czerniak. ");
                    _dialogueChatter.Add("Amos Saxton, here. We have a problem. An patient escaped the miniumum security complex. She" +
                        "will likely still be in the area.");
                    _dialogueChatter.Add("Uh-huh. What's her name? What does she look like?");
                    _dialogueChatter.Add("It's Alice O'Connell. Age: 29. She is white with medium-length " +
                        "long hair. She has extensive injury to her left eye and ");
                    _dialogueChatter.Add("What is she wearing?");
                    _dialogueChatter.Add("Plain clothes.  She may return to her home.  But she'll definitely be a " +
                        "problem.");
                    _dialogueChatter.Add("We can handle it. ");
                    _dialogueChatter.Add("You should be careful.  Because of her psychosis...");
                    _dialogueChatter.Add("I said we can handle it. Gotta run.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day4Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y8") // YASMINE RIVERA calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("City Council Historian, please... and you would do well to listen well... ");

        }
    }
    public void Day4Answer3() // Yasmine calling Emily
    {
        Debug.Log("Day 4, call 3");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X8": //Calling Past President: Emily Hanson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("EmilY: Hi, this is Emily Hanson.  Past President and Historian. What can I do for you?");
                    _dialogueChatter.Add("Yasmine: It has happened once before; this town's history will either lead to its" +
                        " future, or its doom.");
                    _dialogueChatter.Add("EmilY:History? Oh, I agree. While looking through archives, I found out that this " +
                        "town's past is covered with many times it has almost been destroyed. 6 times to be exact.");
                    _dialogueChatter.Add("Yasmine:The Proclamation of the Phoenix");
                    _dialogueChatter.Add("EmilY:In the past, many of the ugly parts of this towns history was attributed to " +
                        "the occult and that very prophecy and yet the town always has pulled through. I'm surprised " +
                        "that you've heard of the Proclamation of the Phoenix. It was wiped from many of the historial " +
                        "text because of the hysteria associated with it.");
                    _dialogueChatter.Add("Yasmine: For your heart and soul fight the Phoenix and the Demon. " +
                        "The ground holds snakes that change with the seasons." +
                        "The mountain shakes loose everything known." +
                        "From the ash reborn. As above; so below.");
                    _dialogueChatter.Add("EmilY: Yes!  It ME at least two decades for me to put " +
                        "together the pieces of the prophecy. This was because mainly no texts " +
                        "listed it at all and if it did, they only had fragments of " +
                        "the prophecy... er-what did you say your name was, again?");
                    _dialogueChatter.Add("...");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day4Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y1") // KINNISON calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, please connect me to Robert Templeton! I must put " +
                "an end to this foolishness.");

        }
    }
    public void Day4Answer4() //Kinnison calling Robert
    {
        Debug.Log("Day 4, call4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y4": //Calling Entertainer: Robert Templeton
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Robert, its Father Kinnison.");
                    _dialogueChatter.Add("What do you want, Father?");
                    _dialogueChatter.Add("You're already agitated.");
                    _dialogueChatter.Add("Well, what should I be?  Grateful?");
                    _dialogueChatter.Add("I know you're angry with God.");
                    _dialogueChatter.Add("Anger doesn't do it justice, Father. He stole my son, my beautiful, healthy son! " +
                        "Healthy right up until he died.");
                    _dialogueChatter.Add("God knows how it feels to lose a son, too.");
                    _dialogueChatter.Add("Don't. Why did you call?");
                    _dialogueChatter.Add("You are justified in your anger, but preying on townspeople, offering them " +
                        "hope where you don't even believe is not the way. You're better than this.");
                    _dialogueChatter.Add("I believed. but all that went away when I held my stillborn son.");
                    _dialogueChatter.Add("...");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day4Call5()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y1") // KINNION calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Peace be unto you, Operator, please connect me to the Blissvill Bank.");

        }
    }
    public void Day4Answer5()//Kinnison calls Rose Williams
    {
        Debug.Log("Day 4, call 5");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A5": //Calling Rose Williams
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Rose: Thank you for calling Rose Williams: Blissville Account Manager. " +
                        "How may I help you?");
                    _dialogueChatter.Add("Hi, Rose, it's Father Kinnison. I'm concerned about unauthorized " +
                        "purchases on the Parish's account. Until I speak with Father Smit, I was wondering if you " +
                        "could restrict his account?");
                    _dialogueChatter.Add("Father, the treasurer of the 77th Parish is the signer " +
                        "on the account. The request must come from him to be valid. I'm sorry.");
                    _dialogueChatter.Add("No, that's alright. Have a blessed day.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day4Call6()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A5") // EMILY calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Tutsie Pattinson, please, Operator. ");

        }
    }
    public void Day4Answer6() //Rose calls Tulip
    {
        Debug.Log("Day 4, call 6");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "C9": //Calling Tulip Pattinson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Tulip: It's Tulip, honey.");
                    _dialogueChatter.Add("Hi, honey, it's Rose.");
                    _dialogueChatter.Add("Girl, spill the beans.");
                    _dialogueChatter.Add("Well, something weird is going on with the Parish.  I'm not sure what it's all about, " +
                        "but one Priest was trying to restrict the others' account. He said he was worried about " +
                        "unauthorized purchases.");
                    _dialogueChatter.Add("Trouble in the Parish? What do you think could be going on?  Did you do it?");
                    _dialogueChatter.Add("I can't without the proper credentials.");
                    _dialogueChatter.Add("OOoh, girl, that is JUI---CY!!!");
                    _dialogueChatter.Add("Anyways, can you pencil me in to get me done up?");
                    _dialogueChatter.Add("Of course, honey what about tommorrow at 5pm?");
                    _dialogueChatter.Add("Perfect!");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day4Call7()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y1") // KINNISON calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator.  Please connect me whatever phone you have on " +
                "file for Benjamin Smit. ");

        }
    }

    public void Day4Answer7() //Kinnison calls Smit
    {
        Debug.Log("Day 4, call 7");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y2": //Calling SMIT
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Smit: Father Smit of the 77th Parish.");
                    _dialogueChatter.Add("Kinnison: Smit. You've been gone from the Parish all day.");
                    _dialogueChatter.Add("Smit: And?");
                    _dialogueChatter.Add("Kinnison: Have you not a flock to attend to?");
                    _dialogueChatter.Add("Smit: Are they at the Parish? No. They are at home, at work... and at school." +
                        "Perhaps you might try going into the field sometime to see what is right before your eyes.");
                    _dialogueChatter.Add("Kinnison: Oh... I see what is before my eyes. I see YOU, Smit. I SEE you.");

                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    //-----------------------Day 5----------------------
    public void Day5Call0()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C7") // LUCAS calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, I need help. La--- dogs chased me into my home... ");

        }
    }

    public void Day5Answer0() //Lucas calling Sheriff
    {
        Debug.Log("Day 5, call 0");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z1": //Calling Sheriff: Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Lucas: Help! It's ----er, Lucas Porter. I was attacked by 2 huge bl-- hosti--" +
                        "animals, dogs but they looked s- ---ge! I'm barely made it ---- -- -----.  I can hear " +
                        "them -- the d--r!");
                    _dialogueChatter.Add("Sheriff: Lucas! Calm down, you're breaking up. Say again!  ");
                    _dialogueChatter.Add("Lucas: 2 big black hostile dogs came after me on my way from the car to the house." +
                        " I made a run for it and barely made it. They are still at the door even now.");
                    _dialogueChatter.Add("Sheriff: Okay. Lock the door. I'm on my way. I'll look for the animals.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            case "Y9": //Calling Code Enforcement: Thomas Sanford
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Lucas: Help! It's ----er, Lucas Porter. I was attacked by 2 huge bl-- hosti" +
                        "animals, dogs but they looked s- ---ge! I'm barely made it ---- -- -----.  I can hear " +
                        "them -- the d--r!");
                    _dialogueChatter.Add("Thomas: Lucas, you're shouting into the phone and breaking up.  Are you safe?");
                    _dialogueChatter.Add("Lucas: Y-yes. But they're still out there!");
                    _dialogueChatter.Add("Thomas: What is?");
                    _dialogueChatter.Add("Lucas: The animals! Those dogs that attacked me!");
                    _dialogueChatter.Add("Thomas: Alright, I'll get the Sheriff over there right away. I'm on my way to " +
                        "meet him. Okay?");
                    _dialogueChatter.Add("Lucas: Okay.  Thank you.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            case "X7": // City Council President: Aria Rodriguez
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Lucas: Hello, It's ----er, Lucas Porter. I was attacked by 2 huge bl-- hosti" +
                        "animals, dogs but they looked s- ---ge! I'm barely made it ---- -- -----.  I can hear " +
                        "them -- the d--r!");
                    _dialogueChatter.Add("Aria: Lucas! Lucas, are you safe!?");
                    _dialogueChatter.Add("Lucas: I am, for now.  ");
                    _dialogueChatter.Add("I just finished meeting with the Sheriff. I'll send him to your home to make " +
                        "sure you're safe and that those dogs don't hurt anyone else. This is why we need a 'Leash your Pet " +
                        "in Public' city ordinance. People need to feel safe in this community. If I'm re-elected...");
                    _dialogueChatter.Add("Lucas: Not now Aria. I can still hear them at the door.");
                    _dialogueChatter.Add("Aria: Right, let me get the Sheriff and send him your way.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending2Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day5Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z1") // SHERIFF calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("*Whistling and humming* Operator, I need the psych doc, please. ");

        }
    }

    public void Day5Answer1() //Sheriff calling PATRICK Walskin
    {
        Debug.Log("Day 5, call 1");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X1": //Calling Psyche Docter: Patrick Walskin
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Walskin, it's Czerniak.");
                    _dialogueChatter.Add("What can I do for you, Sheriff?");
                    _dialogueChatter.Add("I may have found us another head.");
                    _dialogueChatter.Add("Are you sure.  We can't lock up the whole town");
                    _dialogueChatter.Add("Just listen, alright.  Lucas Porter was in hysteria talking about he " +
                        "was accosted by 2 large black dogs. I went to the residence. NO evidence of animals." +
                        "No footprints, drool, excrement, nothing. I did however, find he dropped his bags " +
                        "of groceries. Meet me at the Porter house for an eval. We can go from " +
                        "there.");
                    _dialogueChatter.Add("Okay.  I'll meet you for an evaluation but we kinda need to lay low for a " +
                        "little while.");
                    _dialogueChatter.Add("I hear ya.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day5Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "X0") // HAZEL calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("There's something going on with the water in this town. I'll raise a stink if I " +
                "have to. Aria Rodriguez.  I know she's in her office because I just drove by.");
        }
    }

    public void Day5Answer2() //Hazel more calling Aria
    {
        Debug.Log("Day 5, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X7": //Calling City Council President: Aria Rodriguez
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("City Council President: Aria Rodriguez. How can I help you?");
                    _dialogueChatter.Add("This is Hazel Moore of Smile Moore Dentistry. I'm calling because" +
                        " of disturbing findings between my patients and suspected water " +
                        "contamination.");
                    _dialogueChatter.Add("Yes, the Sheriff has logs and has forwarded me several reports that " +
                        "citizens have made.");
                    _dialogueChatter.Add("My patients, 83% have similiar progressive tooth decay and/or periodontal decay. " +
                        "I've mailed my findings to the office over 5 weeks ago. ");
                    _dialogueChatter.Add("We did receive those documents and that spurred a water " +
                        "contamination test. That test was conducted by our code enforcement officer, Thomas " +
                        "Sanford about 3 weeks ago.  We are still awaiting the results. We WILL send out information" +
                        " as we get it in but we don't want to start a panic or even worse a mass exodus.");
                    _dialogueChatter.Add("I understand. It's good to hear that action has been taken but what are you" +
                        "going to do if the results are in in the next few weeks. Do you have a Plan B?");
                    _dialogueChatter.Add("We will cross that bridge when we get there, IF we don't have results in " +
                        "the next few weeks.");
                    _dialogueChatter.Add("We will see, Madam President. We will see.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day5Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "B6") // OPHELIA calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator! I need someone who... oh.  just send me to Fran.");
        }
    }

    public void Day5Answer3() //Ophelia calling Francesca
    {
        Debug.Log("Day 5, call 3");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z3": //Calling Librarian: Francesca Waller
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Ophelia: Fran! It's Ophie!");
                    _dialogueChatter.Add("Francesca: Hi, Ophie. Why are you whispering?");
                    _dialogueChatter.Add("Ophelia: Listen, you're a librarian so you read a lot of books right? You've " +
                        "got to know something about this stuff.");
                    _dialogueChatter.Add("Francesca: What stuff? What are you talking about?");
                    _dialogueChatter.Add("Ophelia: I've been finding weird occult stuff in the house I clean. Houses " +
                        "that I clean regularly have had weird tiki wreaths made of bones, other occult stuff " +
                        "that I don't even know what they are or how to explain them.");
                    _dialogueChatter.Add("Francesca: I'm guessing you want me to look at the items.");
                    _dialogueChatter.Add("Ophelia: Don't you want to?");
                    _dialogueChatter.Add("Francesca: Of course! I want to know who is putting these around town and " +
                        "could they have anything to do with the weird stuff that has been happening lately?");
                    _dialogueChatter.Add("Ophelia: You know... I've even found them in the Parish. In fact, I've " +
                        "found more in the Parish than any other home.");
                    _dialogueChatter.Add("Francesca: That's really unsettling.");
                    _dialogueChatter.Add("Ophelia: I know. Let's get together soon. We can look at everything " +
                        "and try to make sense of it.");
                    _dialogueChatter.Add("Francesca: Okay, bye.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day5Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "X5") // EVELYN calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator! I need the City Council President. Now.");

        }
    }

    public void Day5Answer4() //Evelyn Porter calls Aria
    {
        Debug.Log("Day 5, call 4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X7": //Calling City Council President: Aria Rodriguez
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Ms. Rodriguez, I've voted for you because I felt that you had and would" +
                        " uphold the value that I have. I'm realizing on the dawn of reelection that " +
                        "I may have made a mistake!");
                    _dialogueChatter.Add("May I ask who I'm speaking to?");
                    _dialogueChatter.Add("This is Evelyn Porter.");
                    _dialogueChatter.Add("Okay, Ms. Porter. Why do you feel you've made a mistake.");
                    _dialogueChatter.Add("I've just spent 5 and a half hours jumping though hoops to get my husband " +
                        "out of the Asylum. Why was he there in the first place? ... I'm glad you asked! He says he was " +
                        "attacked at our home by two big black aggressive dogs. I believe him. But because " +
                        "the Sheriff didn't find proof of dogs, he involuntarily held my husband.  Gave him a hardly believable " +
                        "evaluation and then had him committed.  If it doesn't sound fishy to you, it should." +
                        " This system is corrupt. Someone out there is getting paid and I won't stop till I get to " +
                        "the bottom of this.  I want answers!");
                    _dialogueChatter.Add("I'm sorry that has been your experience, Ms. Porter. I will go to the " +
                        "proper authorities with this information and they may be in touch with you to get your  " +
                        "official statement.");
                    _dialogueChatter.Add("I'm beyond livid! I never should have had to pick my husband " +
                        "up from the Asylum!");
                    _dialogueChatter.Add("I agree. And again, I apologize that you had to go through that. Again, someone " +
                        "may be in touch with you to get an official statement from you.");
                    _dialogueChatter.Add("Sounds a lot like politician speak. I expect to hear from " +
                        "someone soon, Ms. Rodriguez.");

                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day5Call5()
    {
        if (_switchboard2.WhoIsCalling().placementName == "X7") // ARIA calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Whew, hello, Operator? Please get me a deputy on the line. NOT the Sheriff, please.");

        }
    }

    public void Day5Answer5() //Aria calls Deputy
    {
        Debug.Log("Day 5 call 5");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z2": //Calling Deputy: Harry Walskin
                {
                    ResetDialogueIteration();
                    _call_5_5_Walskin = true;
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Aria: Deputy Harry Walskin, it's Aria Rodriguez. I want to to " +
                        "start in informal investigation into the local Asylum.");
                    _dialogueChatter.Add("Harry: ...");
                    _dialogueChatter.Add("Aria: I know you have connections to the Asylum but if the pipeline is " +
                        "corrupt, we have a duty to protect our citizens. And your brother is the evaulating " +
                        "psyche doctor. Wouldn't you want to clear him any wrongdoing? ");
                    _dialogueChatter.Add("Harry: Yes. Why can't you go to the Sheriff with this?");
                    _dialogueChatter.Add("Aria: I have suspicions that the Sheriff is in on it. I'm not sure. But " +
                        "you'll need to report any payments to the Sheriff from the Asylum Accounting books. " +
                        "I'll make sure you get access. Can you do this for me?");
                    _dialogueChatter.Add("Harry: Yes, ma'am.");
                    _dialogueChatter.Add("Aria: Thanks, Harry.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            case "Z8": //Calling Deputy: Willem Tauten
                {
                    ResetDialogueIteration();
                    _call_5_5_Walskin = false;
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Aria: Deputy Willem Tauten, it's Aria Rodriguez. I need you to look" +
                        " into the local Asylum. Before I start a formal investigation.");
                    _dialogueChatter.Add("Willem: Where is this coming from?");
                    _dialogueChatter.Add("Aria: One too many coincidences about citizens being locked up. " +
                        "There's starting to be a pattern and I don't like it.");
                    _dialogueChatter.Add("Willem: Really? Cause back at the station, when we get a whiff of anything " +
                        "that stinks, we check it out.");
                    _dialogueChatter.Add("Aria: I have suspicions that the Sheriff is in on it. I'm not sure. But " +
                        "you'll need to report any payments to the Sheriff from the Asylum Accounting books. " +
                        "I'll make sure you get access. Can you do this for me?");
                    _dialogueChatter.Add("Willem: Okay. I hope you're wrong but I'll look into it.");
                    _dialogueChatter.Add("Aria: Don't draw attention to yourself.");
                    _dialogueChatter.Add("Willem: Of course not; I'm a professional.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day5Call6()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A1") // THEODORE calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Please connect me Bourne to Build Construction Company, Operator.");

        }
    }

    public void Day5Answer6() //Theodore calling Hugo Bourne
    {
        Debug.Log("Day 5, call 7");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A9": //Calling Construction Worker: Hugo Bourne
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Bourne to Build Construction Company: Hugo Bourne on the line. What can I do ya for?");
                    _dialogueChatter.Add("It's Theodore Walker. I'm in need of repairs in the mines and heard" +
                        " you were the man for the job.");
                    _dialogueChatter.Add("Alright, I can come by tomorrow to take a look at the repairs needed and " +
                        "draw you up a bid. Does that work for you?");
                    _dialogueChatter.Add("It does.  Thank you.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Day5Call7()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A8") // ALICE calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello Operator?");
            _dialogueChatter.Add("Hello?");
            _dialogueChatter.Add("We need you need to gather these people in the Mines:");
            _dialogueChatter.Add("How");
            _dialogueChatter.Add("Call them.");
            _dialogueChatter.Add("Helper, Taker, Ringer, Breaker...Helper, Taker, Ringer, Breaker...");

        }
    }

    public void Day5Answer7() //Alice Calling Operator
    {
        Debug.Log("Day 5, call 6");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X9": //Calling Operator
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Helper, Taker, Ringer, Breaker...Helper, Taker, Ringer, Breaker...");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }



    //-----------------------Day 6----------------------

    public void Day6Call0()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z3") // FRAN calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hi Operator, I'm looking for the Medium? Maybe it's nothing, but " +
                "I have a feeling we're all in trouble in this town...");

        }
    }

    public void Day6Answer0() //Francesca calls Doris Minko
    {
        Debug.Log("Day 6, call 0");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y0": //Calling Medium: Doris Minko
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Is this Doris Minko? This is Francesca Waller.");
                    _dialogueChatter.Add("Hi Francesca. How can I help you?");
                    _dialogueChatter.Add("I have in my possession some items of the occult found by my friend." +
                        " I was wondering if you'd be willing to take a look at them.");
                    _dialogueChatter.Add("Where did your friend find them?");
                    _dialogueChatter.Add("Okay, this is going to sound weird, but they've been turning up in " +
                        "multiple houses... and even the Parish.");
                    _dialogueChatter.Add("And you friend has access to multiple houses and even the Parish?");
                    _dialogueChatter.Add("Yes. But you know when something doesn't belong somewhere. We've " +
                        "been using gloves when we handle them because we don't know exactly what they are. I've" +
                        "researched some of them, and that's how we determined that they were occult items. But" +
                        " that leaves the question, what are they doing scattered around town?");
                    _dialogueChatter.Add("Well, you certainly have my curiousity piqued. Come by my office... you " +
                        "and your friend.");
                    _dialogueChatter.Add("Alright, thank you so much.");
                    _dialogueChatter.Add("No, thank you.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day6Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y0") // DORIS calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator? I need to talk to someone who would know much about " +
                "these dark magic items being left all over town.");

        }
    }

    public void Day6Answer1() //Doris calls Priest
    {
        Debug.Log("Day 6, call 1");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y1": //Calling Priest: Tallehasse Kinnison
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Doris: This is Doris Minko, I'm looking for a clergy member.");
                    _dialogueChatter.Add("Father Kinnison: Uh, okay.  This is Father Tallehasse Kinnison. " +
                        "How may I help you?");
                    _dialogueChatter.Add("Doris: Father, something foul is afoot. What I mean to say is that " +
                        "many occult items are being, have been left in your Parish and in homes around town. " +
                        "Do you know of what I speak?");
                    _dialogueChatter.Add("Father Kinnison: Unfortunately, I do have an idea of what you mean. " +
                        "Catholicism is big on ritual but what I've been finding around the Parish as of late " +
                        "is nothing that we use and should not be on holy ground as not to defile it.");
                    _dialogueChatter.Add("Doris: What will you do?");
                    _dialogueChatter.Add("Father Kinnison: What I can. With God, all things are possible if " +
                        "we have only faith the size of a mustard seed.");
                    _dialogueChatter.Add("Doris: God be with you, Father.");
                    _dialogueChatter.Add("Father Kinnison: And also with you, Doris.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            case "Y2": //Calling Priest: Benjamin Smit
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Doris: This is Doris Minko, I'm looking for a clergy member.");
                    _dialogueChatter.Add("Father Smit: Father Benjamin Smit, at your service.");
                    _dialogueChatter.Add("Doris: Father, have you seen any strange occult items left in the Parish or " +
                        "heard any of your congregants speak of finding strange things like talismans, amulets, " +
                        "totems left in their houses.");
                    _dialogueChatter.Add("Father Smit: No, why?");
                    _dialogueChatter.Add("Doris: I have reason to believe that someone is planning to use the " +
                        "occult items for ill purpose.");
                    _dialogueChatter.Add("Father Smit: Do you have any of the items in your possession?");
                    _dialogueChatter.Add("Doris: I do.");
                    _dialogueChatter.Add("Father Smit: Can you tell me what you know of them.");
                    _dialogueChatter.Add("Doris: It's some of what I named before: talismans, amulets, totems " +
                        "of bones and sticks, a few tarot cards and some crystals.");
                    _dialogueChatter.Add("Father Smit: I am not worried about these trinkets, Doris. And you s" +
                        "hould not worry either. For the blood of Lamb covers his own to allow the Angel of " +
                        "Death to passover. All is as it will be and should be.");
                    _dialogueChatter.Add("I hope you're right, Father Smit.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day6Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C1") // HELEN calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, please get Charlie on the line!");

        }
    }

    public void Day6Answer2() //Helen calls Sheriff
    {
        Debug.Log("Day 6, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z1": //Calling Sheriff: Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Sheriff, this is Helen Wanton. I'm a waitress at the local diner " +
                        "downtown.");
                    _dialogueChatter.Add("What can I do for you?");
                    _dialogueChatter.Add("I had an unusual customer just now. She was wearing jeans and a " +
                        "plaid flannel shirt. Blonde shoulder length hair.");
                    _dialogueChatter.Add("What did she do. Did she dine and dash?");
                    _dialogueChatter.Add("She had a large bandage wrapped around her head and left eye. It " +
                        "was a little hard to tell with all the bruising but I could have sworn it was Alice" +
                        " O'Connell. You know, by now, the whole town knows she tore out her own eyeball. But " +
                        "in the event you all misplaced a patient, I thought I would give a call.");
                    _dialogueChatter.Add("Thank you. She has been missing. We decided not to notify the public " +
                        "as she is not a public threat. Which way did you say she went?");
                    _dialogueChatter.Add("I didn't see after she paid and left the diner, actually. But she's " +
                        "probably still around.  It's been about 10 minutes since she left.");
                    _dialogueChatter.Add("Okay, thank you, Helen.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day6Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z3") // FRAN calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, I need you to connect me to Caroline Walden. And please, don't " +
                "repeat any of what you're about to hear...");

        }
    }

    public void Day6Answer3() //Francesca calling Caroline
    {
        Debug.Log("Day 6, call 3");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "B7": //Calling Launderer: Caroline Walden
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Francesca: Caroline! It's Fran. I want you to be careful. Some weird" +
                        " stuff has been happening around town.");
                    _dialogueChatter.Add("Caroline: Like what?! You're scaring me.");
                    _dialogueChatter.Add("Francesca: You know Ophie? Well she's found like tiki totems made of " +
                        "bones, crystals, talismans and other magic stuff in peoples' homes.  I figured you" +
                        " probably found stuff like that being a launderer in all, right?");
                    _dialogueChatter.Add("Caroline: ...");
                    _dialogueChatter.Add("Francesca: You have, haven't you?");
                    _dialogueChatter.Add("Caroline: Actually, I found some weird stuff while dry-cleaning some  " +
                        "clothing from the Parish. Talismans, papers, bones.  I'm not sure who it belongs to " +
                        "but when items are left in the pockets, I just bag it and tag it for return to the " +
                        "owners. This time, it felt weird to find these things in the pockets.");
                    _dialogueChatter.Add("Francesca: Be careful. We don't know who is leaving this stuff around" +
                        " town!");
                    _dialogueChatter.Add("Caroline: I gotta go, Father Smit is here to pick up the clothes. ");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day6Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A9") // HUGO calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hi, Operator? This is Hugo Bourne of the Bourne to Build Construction company.  I " +
                "need to speak with Theodore Walker");

        }
    }

    public void Day6Answer4() //Hugo callling Theo
    {
        Debug.Log("Day 6, call 4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A1": //Calling Theo
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("It's Theo Walker, speak.");
                    _dialogueChatter.Add("You certainly get straight to the point.  So will I.  It's Hugo Bourne." +
                        "I received the signed contract on the bid and will begin working on the repairs tomorrow.");
                    _dialogueChatter.Add("Perfect. We will have an audit, but it should not interfere with your " +
                        "work.");
                    _dialogueChatter.Add("Alright!  Thank you for that relief.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day6Call5()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z9") // LEVI calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello Operator? I'm looking to speak with either Michael Walker" +
                " or Sheriff Czerniak? It's about the mines?");

        }
    }

    public void Day6Answer5() //Levi calling Michael
    {
        Debug.Log("Day 6, call 5");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A0": //Calling Michael Walker
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Hi, is this Michael Walker");
                    _dialogueChatter.Add("Yes.  How can I help you.");
                    _dialogueChatter.Add("My name is Levi Johnson. I'm a local teacher. Many students have been " +
                        "talking about a mine party where there is sure to be alcohol. I don't know if you heard " +
                        "anything about it.");
                    _dialogueChatter.Add("No, but that's the last thing we need is a bunch of teenagers getting " +
                        "lost or hurt.");
                    _dialogueChatter.Add("I'm relieved to hear you say that. I don't know what day they are " +
                        "planning this.");
                    _dialogueChatter.Add("Is doesn't matter.  I'll hire extra security to guard the mines. " +
                        "Thanks for bringing this to my attention.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            case "Z1": //Calling Sheriff
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Sheriff Czerniak.  What is it now?");
                    _dialogueChatter.Add("My name is Levi Johnson. I'm a local teacher. Many students have been " +
                        "talking about a mine party where there is sure to be alcohol. I don't know if you heard " +
                        "anything about it.");
                    _dialogueChatter.Add("Aw, jeez. No, I haven't heard anything about it till now." +
                        " It was only a matter of time before they would want to climb " +
                        "down in there. Only to get hurt, stuck, or worse. Kids are dumb...");
                    _dialogueChatter.Add("... I haven't been able to catch the day they are planning this.");
                    _dialogueChatter.Add("That's okay. You've done your community a huge service. I'll see " +
                        "what I can do.");
                    _dialogueChatter.Add("Thank you, Sheriff");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day6Call6()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A8") // ALICE calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator... I need a priest.");

        }
    }

    public void Day6Answer6() //Alice calling Father Kinnison
    {
        Debug.Log("Day 6, call 6");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y1": //Calling Father Kinnison
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Kinnison: Father Kinnion of the 77th Parish.  How may I serve you?");
                    _dialogueChatter.Add("Alice: I'm looking to schedule a confession. I apologize, but I've never met " +
                        "with you. Is Father Smit available?");
                    _dialogueChatter.Add("Kinnison: I apologize, my child. Father Smit is... has been gone missing.");
                    _dialogueChatter.Add("Alice: Oh?");
                    _dialogueChatter.Add("Kinnison: I'm afraid he isn't well. But never fear, God's grace can be ours. All " +
                        "we need do is accept the blood of the lamb.");
                    _dialogueChatter.Add("Alice: Yes, Father. ");
                    _dialogueChatter.Add("Kinnison: Go in peace.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();

                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day6Call7()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z3") // FRAN calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("I need someone knowledgeable in things like supernatural, talismans, " +
                "amulets, and the like?");

        }
    }

    public void Day6Answer7() //Francesca calling Xena Pattinson
    { 
        Debug.Log("Day 6, call 7");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y6": //calling Xena
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Xena: Xena Pattinson, Curiousity and Oddities Expert. " +
                        "How can I help you?");
                    _dialogueChatter.Add("Francesca: It's Francesca. Did you get the package I " +
                        "left in your mailbox.");
                    _dialogueChatter.Add("Xena: That, I did. I had a chance to look at the items. How did you " +
                        "come by these?");
                    _dialogueChatter.Add("Francesca: Well, my friend Ophelia has been finding some of these " +
                        "in the houses she cleans. And then my other friend, Caroline, is the only" +
                        " launder business in town.  She says she started finding these things in the Parish's vestments " +
                        "a few days ago.");
                    _dialogueChatter.Add("Xena: Some of these are very old. And some of them look like they " +
                        "could be used for ritual sacrifice.");
                    _dialogueChatter.Add("Francesca: How can you tell?");
                    _dialogueChatter.Add("Xena: Let's meet in town. Isn't there a motel?  I would't and didn't " +
                        "bring them into MY home for a reason.");
                    _dialogueChatter.Add("Francesca: I'll get us a room.");
                    _dialogueChatter.Add("Xena: I'll be in town in two days time.");
                    _dialogueChatter.Add("Francesca: I'll be ready with the room.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day6Call8()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z3") // FRAN calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hi, Operator? Please transfer me to Mitchell Motel. ");

        }
    }

    public void Day6Answer8() //Francesca calls Christina Mitchell
    {
        Debug.Log("Day 6, call 8");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "B1": //Calling Motel Owner: Christina Mitchell
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Christina: Mitchell Motel, Christina Mitchell speaking.");
                    _dialogueChatter.Add("Francesca: Hi Christina, this is Francesca.");
                    _dialogueChatter.Add("Christina: Ah, yes. How can I help you?");
                    _dialogueChatter.Add("Francesca: I need a room for 2 nights, but I won't need it until 2 nights " +
                        "from now. Can you pencil me in?  I need this hush-hush too.");
                    _dialogueChatter.Add("Christina: Sure, it's not like I get audited; why all the secrecy?");
                    _dialogueChatter.Add("Francesca: I'll explain when we get there. But something's not right.");
                    _dialogueChatter.Add("Christina: I've felt it for some time. I'll see you when you get here.");
                    _dialogueChatter.Add("Francesca: Thanks, Christina.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    //-----------------------Day 7----------------------

    public void Day7Call0()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y5") // XENA calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello Operator.");
            _dialogueChatter.Add("It must be hard to hear everything this town has to offer?");
            _dialogueChatter.Add("Do you feel helpless?");
            _dialogueChatter.Add("Well, you can help us find the people we need to bind our foe.");
            _dialogueChatter.Add("Will you help us?");
            _dialogueChatter.Add("We need to find the the taker, the seer, the helper, and the breaker.");
            _dialogueChatter.Add("I'll let you know when we're ready");
            _dialogueChatter.Add("Now, onto business: I need to speak with someone from the 77th Parish?");
        }
    }

    public void Day7Answer0() //Xena calling Father Kinnison
    {
        Debug.Log("Day 7, call 0");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y1": //Calling Priest: Tallehasse Kinnison
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Father Kinnison: 77th Parish, this is Father Kinnison.");
                    _dialogueChatter.Add("Xena: Father, you don't know me, but I have reason to believe " +
                        "that there is a wolf in sheep's clothing hiding in plain sight. I don't know who " +
                        "but I have an entire envelope of occult items supposedly found in vestments sent " +
                        "for laundering. If they aren't yours, then whose?");
                    _dialogueChatter.Add("Father Kinnison: I may have an idea of who. Who gave you these items?");
                    _dialogueChatter.Add("Xena: They showed up on my doorstep with a letter.");
                    _dialogueChatter.Add("Father Kinnison: And I should trust you? This voice on the phone?");
                    _dialogueChatter.Add("Xena: Trust your God.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day7Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y2") // SMIT calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, we've not time to waste. Please transfer me to Luanne from " +
                "the General Store.");

        }
    }

    public void Day7Answer1() //Smit calling Luanne
    {
        Debug.Log("Day 7, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A3": //Calling General Store: Luanne Bourne
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Luanne: This is the General Store. I'm Luanne.");
                    _dialogueChatter.Add("Father Smit: Hi Luanne, I need a few items.");
                    _dialogueChatter.Add("Luanne: Okay, I'm ready.");
                    _dialogueChatter.Add("Father Smit: I need a refill on lantern oil, flares...  ");
                    _dialogueChatter.Add("Luanne: Uh-huh, uh-huh, yep, got it.");
                    _dialogueChatter.Add("Father Smit: Matches, and a bag, a potato sack will do. He will " +
                        "gather his wheat into the barn, but the chaff he will burn with unquenchable fire...");
                    _dialogueChatter.Add("Luanne: I didn't catch that, Father.");
                    _dialogueChatter.Add("Father Smit: Matthew 3:12");
                    _dialogueChatter.Add("Luanne: Riiiight... so I'll gather up your order. Luckily, we have " +
                        "all of this on hand. It'll be ready in about an hour for pick up.");
                    _dialogueChatter.Add("Father Smit: Thanks.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day7Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "X0") // Hazel calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("This is Hazel Moore, the dentist. I need to talk to someone about " +
                "the danger the mines pose to this community. ");

        }
    }

    public void Day7Answer2() //Hazel calling Evelyn
    {
        Debug.Log("Day 7, call 3");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X5": //Calling Eye Doctor: Evelyn Porter
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Evelyn: Porterhouse Ophthalmology, Doctor Porter.");
                    _dialogueChatter.Add("Hazel: This is Dr. Hazel Moore of Smile Moore Dentistry ");
                    _dialogueChatter.Add("Evelyn: What can I do for you.  ");
                    _dialogueChatter.Add("Hazel: I'm putting together a case to open an investigation " +
                        "into the mines. I have reason to believe it has contaminated the water.");
                    _dialogueChatter.Add("Evelyn: From my patients, I've heard more than a few stories " +
                        "of them being attacked by what they think was a dog or dogs. But they can " +
                        "never give an exact description. Do you think these possible hallucinations are " +
                        "related to the mines?");
                    _dialogueChatter.Add("Hazel: I don't know, but I'd like to include any information you " +
                        "can provide.  I've spoken with Doctor Miles Hanson.  He confirmed strange bruising " +
                        "in otherwise healthy patients.  It can't all be a coincidence.");
                    _dialogueChatter.Add("Evelyn: Alright. I'll reach out to those patients and see if they're " +
                        "willing to give an account");
                    _dialogueChatter.Add("Hazel: Thank you.  I'll present it to Thom tomorrow.");
                    _dialogueChatter.Add("Evelyn: Thank you.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            case "Y9": //Calling Eye Doctor: Thomas Sanford
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Thom: Hiya, this is Thomas Sanford.");
                    _dialogueChatter.Add("Hazel: This is Dr. Hazel Moore of Smile Moore Dentistry ");
                    _dialogueChatter.Add("Thom: What can I do for you?");
                    _dialogueChatter.Add("Hazel: I need your help! I have reason to believe the mines have contaminated " +
                        "the water and may potentially have other negative environmental fallout.");
                    _dialogueChatter.Add("Thom: I agree. We are on schedule to received our sample analysis " +
                        "today with the mail. That should tell us more.");
                    _dialogueChatter.Add("Hazel:  I've spoken with Doctor Miles Hanson.  He confirmed strange bruising " +
                        "in otherwise healthy patients.  It can't all be a coincidence.");
                    _dialogueChatter.Add("Thom: Alright. I'll reach out to those patients and see if they're " +
                        "willing to give an account.");
                    _dialogueChatter.Add("Hazel: Thank you, Thom");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
                    default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day7Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y2") // SMIT calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator. This is Benjamin Smit. I'm in need of helper with expert " +
                "knowledge of spiritual practices?");

        }
    }

    public void Day7Answer3() //Smit calling Yasmine
    {
        Debug.Log("Day 7, call 4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y8": //Calling  Yasmine Rivera
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Yasmine: Hello, this is Yasmine.");
                    _dialogueChatter.Add("Father Smit: Yasmine, I'm in need of sifter");
                    _dialogueChatter.Add("Yasmine: You finally called...");
                    _dialogueChatter.Add("Father Smit: I need help separating the wheat from the chaff.");
                    _dialogueChatter.Add("Yasmine: And how to do you plan to do that?");
                    _dialogueChatter.Add("Father Smit: The number 1 barrier to faith... is fear.  And yet fear breeds faith");
                    _dialogueChatter.Add("Yasmine: I'm listening.");
                    _dialogueChatter.Add("Father Smit: Grab your things and meet me.");
                    _dialogueChatter.Add("Yasmine: Where?");
                    _dialogueChatter.Add("Father Smit: You know where.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending4Count++;
                    break;
                }
            case "Y5": //Calling Occult Expert: Xena Pattinson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Xena: Xena, Oddities and Curiousities Expert, at your service. ");
                    _dialogueChatter.Add("Smit: It's Father Smit... I'm in need of a sifter. ");
                    _dialogueChatter.Add("Xena: I'm not sure I follow. This is a Curi-oddities shop. ");
                    _dialogueChatter.Add("Smit: I need help separating the wheat from the chaff. ");
                    _dialogueChatter.Add("Xena: Okay... I don't think I can help you. ");
                    _dialogueChatter.Add("Smit: The number 1 barrier to faith... is fear. Are you standing in faith? " +
                        "Or are you standing in fear.");
                    _dialogueChatter.Add("Xena: I'm standing in whatever you're planning. It's not good and I will " +
                        "see you found out.");
                    _dialogueChatter.Add("Smit: Nevermind. I don't need you.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    ending1Count++;
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day7Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C5") // LEONARD calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Yello, Operator? Please connect me to Father Kinnison.");

        }
    }

    public void Day7Answer4() //Leonard calls Brother/Priest
    {
        Debug.Log("Day 7, call 5");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Y1": //Calling Priest: Father Kinnison
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Father Kinnison: Father Kinnison of the 77th Parish. How many I help you?");
                    _dialogueChatter.Add("Leonard: It's Leonard, brother.");
                    _dialogueChatter.Add("Father Kinnison: That's Father to you. I don't see you at mass" +
                        "often enough. How are you?");
                    _dialogueChatter.Add("Leonard: I need prayers, Father. I got messed up working in those damned " +
                        "mines; I lost pay but I'm recovering.");
                    _dialogueChatter.Add("Father Kinnison: I'll pray for you, brother. Truthfully, I want to see those " +
                        "mines closed for good. It's too dangerous.");
                    _dialogueChatter.Add("Leonard: I hear you, but it keeps putting food on the table. ");
                    _dialogueChatter.Add("Father Kinnison: At what cost?");
                    _dialogueChatter.Add("Leonard: We can't all be priests; you'd be out of a job.");
                    _dialogueChatter.Add("Father Kinnison: Haha... hang on. There's someone here.");
                    _dialogueChatter.Add("Leonard: *Hears struggle and screaming* Brother, are you alright?!");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day7Call5()
    {
        if (_switchboard2.WhoIsCalling().placementName == "B1") // CHRISTINA calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator! I need the Sheriff, now!");

        }
    }

    public void Day7Answer5() //Christina calling Sheriff
    {
        Debug.Log("Day 7, call 6");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z2": //Calling Sheriff: Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Sheriff: Sheriff Czerniak. Speak.");
                    _dialogueChatter.Add("Christina: Sheriff, it's Christina from the Motel. The Parish. Is. On. Fire!!!");
                    _dialogueChatter.Add("Sheriff: HWhat?!");
                    _dialogueChatter.Add("Christina: You've got to get people over there; it's going up in flames.");
                    _dialogueChatter.Add("Sheriff: Alright, I'm dispatching the deputies now.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    //-----------------------Day 8----------------------

    public void Day8Call0()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A0") // MICHAEL calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, please transfer me to Theodore Walker.");

        }
    }

    public void Day8Answer0() //Michael calling Theo
    {
        Debug.Log("Day 8, call 0");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A1": //Calling Mine Supervisor: Theo Walker
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Theo, it's me.");
                    _dialogueChatter.Add("Right. I've got a contract to repair the beams and structural " +
                        "integrity where needed.");
                    _dialogueChatter.Add("That's not what I'm calling about.  The Sheriff informed me that he received a " +
                        "call from a teacher from the local high school. Apparently, this teacher has overheard " +
                        "some kids planning to sneak into the mines for a party." +
                        "I told him we'd hire extra security to prevent this from happening.");
                    _dialogueChatter.Add("The last thing we need is kids getting hurt or lost in the mines.");
                    _dialogueChatter.Add("I said the same thing. I'm going to send a guy over to you. He already " +
                        "has a team in place that can provide the security we need.");
                    _dialogueChatter.Add("Thanks.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }

    public void Day8Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A2") // AMOS calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hello, Operator. I'd like to return a call to the deputy " +
                "who tried to reach me earlier?");

        }
    }

    public void Day8Answer1() //Amos Saxton return call to deputy...
    {
        Debug.Log("Day 8, call 1");
        if (_call_5_5_Walskin == true)
        {
            switch (_switchboard2.WhoIsAnswering().placementName)
            {
                case "Z2": //Calling Deputy: Harry Walskin
                    {

                        ResetDialogueIteration();
                        _dialogueChatter.Clear();
                        //_dialogueChatter.Add("");
                        _dialogueChatter.Add("This is Warden Amos Saxton. I'm returning a call left to my secretary.");
                        _dialogueChatter.Add("Deputy Walskin, here.");
                        _dialogueChatter.Add("Ah, not the usual Walskin brother I'm used to hearing from. How can I " +
                            "help you?");
                        _dialogueChatter.Add("Look, the City Council President, Aria, wants me to look into the " +
                            "intake practices of the Asylum and the books and all that.  Obviously, I'm not going " +
                            "to able to hold them off for long. This is your sign to get your affairs " +
                            "in order before the real investigation begins. I can only play dumb so long.");
                        _dialogueChatter.Add("Alright, I appreciate the call.");
                        _dialogueChatter.Add("Alright. Good day.");
                        _dialogueChatter.Add("You too, Deputy.");
                        _switchboard2.AdvanceCallCount();
                        _switchboard2.CallIsComplete();
                        break;
                    }
                case "Y8": //Calling Deputy: William Tauten
                    {
                        ResetDialogueIteration();
                        _dialogueChatter.Clear();
                        //_dialogueChatter.Add("");
                        _dialogueChatter.Add("Warden Amos: This is Warden Amos Saxton. I'm returning a call left to my secretary.");
                        _dialogueChatter.Add("Deputy Tauten: This is Deputy Tauten. I haven't left any messages with your office. " +
                            "It must have been Deputy Walskin.");
                        _dialogueChatter.Add("Warden Amos: Alright, sorry to have bothered you.");
                        _dialogueChatter.Add("Deputy Tauten: Quite alright. Have a nice day.");
                        _switchboard2.AdvanceCallCount();
                        _switchboard2.CallIsComplete();
                        break;
                    }
                default:
                    {
                        Debug.Log("There was no answer.");
                        //No answer
                        break;
                    }
            }
        }
        else
        {
            switch (_switchboard2.WhoIsAnswering().placementName)
            {
                case "Z2": //Calling Deputy: Harry Walskin
                    {
                        ResetDialogueIteration();
                        //_call_5_5_Walskin == false
                        _dialogueChatter.Clear();
                        //_dialogueChatter.Add("");
                        _dialogueChatter.Add("Warden Amos: This is Warden Amos Saxton. I'm " +
                            "returning a call left to my secretary.");
                        _dialogueChatter.Add("Deputy Walskin: This is Deputy Walskin. I haven't left any messages with your office. " +
                            "It must have been Deputy Tauten.");
                        _dialogueChatter.Add("Warden Amos: Alright, sorry to have bothered you.");
                        _dialogueChatter.Add("Deputy Walskin: Quite alright. Have a nice day.");
                        _switchboard2.AdvanceCallCount();
                        _switchboard2.CallIsComplete();
                        break;
                    }
                case "Y8": //Calling Deputy: William Tauten
                    {
                        ResetDialogueIteration();
                        _dialogueChatter.Clear();
                        //_dialogueChatter.Add("");
                        _dialogueChatter.Add("Warden Amos: This is Warden Amos Saxton. I'm " +
                            "returning a call left to my secretary.");
                        _dialogueChatter.Add("Deputy Tauten: Yes, I want to schedule a time to sit with you. There is " +
                            "an investigation underway and I think you may have some valuable information that can help " +
                            "with it.");
                        _dialogueChatter.Add("Warden Amos: Uhh, okay. Concerning what, exactly?");
                        _dialogueChatter.Add("Deputy Tauten: Well, I won't be coy. If you have nothing hide, " +
                            "it shouldn't matter. I have questions about the intake practices used by your " +
                            "hospital.");
                        _dialogueChatter.Add("Warden Amos: Okay. Yes. Why don't you come by the Hospital. I'll be " +
                            "happy to speak with you.");
                        _dialogueChatter.Add("Deputy Tauten: Thank you. ");
                        _switchboard2.AdvanceCallCount();
                        _switchboard2.CallIsComplete();
                        break;
                    }
                default:
                    {
                        Debug.Log("There was no answer.");
                        //No answer
                        break;
                    }
            }
        }
    }

    public void Day8Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C6") // BEATRICE calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, I need you to connect me to Tutsie, please");

        }
    }

    public void Day8Answer2() //Beatrice calling Tulip
    {
        Debug.Log("Day 8, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "C9": //Calling Hairdresser: Tulip Pattinson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Tulip: It's Tulip, honey");
                    _dialogueChatter.Add("Beatrice: Hi girl, it's me.");
                    _dialogueChatter.Add("Tulip: Girl! Did you hear about the Parish burning down?");
                    _dialogueChatter.Add("Beatrice: I smelled it!!! But yeah, I heard about it too.");
                    _dialogueChatter.Add("Tulip: Who would do such a thing.");
                    _dialogueChatter.Add("Beatrice: And, I just saw Frannie, you know, the Librarian." +
                        "She and some woman who I don't know, just went into the motel... same room.");
                    _dialogueChatter.Add("Tulip: Same room?");
                    _dialogueChatter.Add("Beatrice: They had a bunch of bags and books stuff.");
                    _dialogueChatter.Add("Tulip: Well, I HEARD the mines are about to be shut down. A bunch of people," +
                        "young folks, are trying to party at the bottom of the mines at midnight in 2 days time.");
                    _dialogueChatter.Add("Beatrice: That's so risky. What is wrong with people?");
                    _dialogueChatter.Add("Tulip: Well, without those mines, this town is going to " +
                        "dry up real quick. Maybe it's one last rodeo. I also heard " +
                        "about the bottom of the mines being a gateway to hell, so " +
                        "I don't know. I just work here.");
                    _dialogueChatter.Add("Beatrice: Girl, if that aint the truth. Well, I didn't want nothing " +
                        "but to call you and chat.  I'm going to let you go now.");
                    _dialogueChatter.Add("Tulip: Alright, now.  Too much honey for ya money! Love ya.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }

    }

    public void Day8Call3()
    { 
        if (_call_5_6_Tauten == true)
        {
            if (_switchboard2.WhoIsCalling().placementName == "Z8") // TAUTEN calling
            {
                ResetDialogueIteration();
                _dialogueChatter.Clear();
                //_dialogueChatter.Add("");
                _dialogueChatter.Add("Hello, Operator. I'd like to speak to the City Council President, please.");
            }
        }
        else
        {
            if (_switchboard2.WhoIsCalling().placementName == "Z2") // WALSKIN calling
            {
                ResetDialogueIteration();
                _dialogueChatter.Clear();
                //_dialogueChatter.Add("");
                _dialogueChatter.Add("Operator, please transfer me to the City Council President.");
            }
        }
    }

    public void Day8Answer3() //Tauten or Walskin calling Aria Rodriguez
    {
        Debug.Log("Day 8, call 3");
        if (_call_5_6_Tauten == true)
        {
            switch (_switchboard2.WhoIsAnswering().placementName)
            {
                case "X7": //Calling City Council President: Aria Rodriguez
                    {
                        ResetDialogueIteration();
                        _dialogueChatter.Clear();
                        //_dialogueChatter.Add("");
                        _dialogueChatter.Add("Aria: City Council President, Aria Rodriguez speaking.");
                        _dialogueChatter.Add("Deputy Tauten: It's Deputy Tauten. I looked into the matter we discussed " +
                            "previously and it is as you suspected.");
                        _dialogueChatter.Add("Aria: Why are you being so vague?");
                        _dialogueChatter.Add("Deputy Tauten: I can't speak freely now. The Sheriff " +
                            "has eyes and ears everywhere. I'm concerned they're on to me.  But I wanted you to know" +
                            "You were right to suspect. I gotta go.");
                        _dialogueChatter.Add("Okay. I'll take it from here.");
                        _switchboard2.AdvanceCallCount();
                        _switchboard2.CallIsComplete();
                        break;
                    }
                default:
                    {
                        Debug.Log("There was no answer.");
                        //No answer
                        break;
                    }
            }
        }
        else
        {
            switch (_switchboard2.WhoIsAnswering().placementName)
            {
                case "X7": //Calling City Council President: Aria Rodriguez
                    {
                        ResetDialogueIteration();
                        _dialogueChatter.Clear();
                        //_dialogueChatter.Add("");
                        _dialogueChatter.Add("Aria: City Council President, Aria Rodriguez speaking.");
                        _dialogueChatter.Add("Deputy Walskin: I looked into the books of the Asylum. ");
                        _dialogueChatter.Add("Aria: What did you find?");
                        _dialogueChatter.Add("Deputy Walskin: Nothing. They get paid from the state for every head " +
                            "in every bed that stays for more than 30 days.");
                        _dialogueChatter.Add("Aria: What about their intake practices?");
                        _dialogueChatter.Add("Deputy Walskin: The intake practices mostly rests on Patrick " +
                            "Walskin, my brother. He makes the evaluation and determines if the patient would benefit " +
                            "from a safe environment and if the patient is a danger to themselves or others. " +
                            "There was a recent incident with Lucas Porter. He was evaluated by Patrick " +
                            "Walskin who is qualified to determine if he was in a state of psychosis... " +
                            "which he was. He was hysterical. Sheriff Czerniak found no evidence of animals, " +
                            "dogs or otherwise at the Porter residence.");
                        _dialogueChatter.Add("Aria: There was no trail of money being exchanged between Dr. " +
                            "Walskin, Sheriff Czerniak or the Asylum?");
                        _dialogueChatter.Add("Deputy Walskin: Well, Dr. Walskin is on the payroll as a floating " +
                            "consultant.  But that's nothing unusual.");
                        _dialogueChatter.Add("Aria: Yes, you're right. Thank you for doing due diligence in this " +
                            "matter.");
                        _dialogueChatter.Add("Deputy Walskin: Anything else?");
                        _dialogueChatter.Add("Aria: No. Thank you again for looking into that for me.");
                        _switchboard2.AdvanceCallCount();
                        _switchboard2.CallIsComplete();
                        break;
                    }
                default:
                    {
                        Debug.Log("There was no answer.");
                        //No answer
                        break;
                    }
            }
        }

    }

    public void Day8Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "A4") // HENRY calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Hi, Operator. Please send me over to Zachariah Lightfoot.");

        }
    }

    public void Day8Answer4() //Henry calls Zachariah
    {
        Debug.Log("Day 8, call 4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A6": //Miner:  Zachariah Lightfoot
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Zachariah: This Zachariah Lightfoot.");
                    _dialogueChatter.Add("Henry: Hi, Zachariah. My name is Henry. I'm a nurse at the hospital.");
                    _dialogueChatter.Add("Zachariah: Oh no. What's happened");
                    _dialogueChatter.Add("Henry: It's Ophelia. She came in with tremors and incoherent. We've got " +
                        "her currently sedated to stop the tremors. When you come to the hospital sign in " +
                        "with the receptionist who will tell you the room she's in.");
                    _dialogueChatter.Add("Zachariah: What happened to her? Do you have any information!?");
                    _dialogueChatter.Add("Henry: There's a more pressing matter. Sir, some people want " +
                        "to see her committed. The doctor on duty, Dr. Miles Hanson feels that it's too " +
                        "soon to make that determination. Without the next of kin to make that decision, " +
                        "it may be made for her.");
                    _dialogueChatter.Add("Okay... okay. I'm on my way.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }


    //------------Ending 4 - Bad Ending -------

    public void Ending4Call0()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C8") // LIAM calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator! I need help! A brawl broke out in my bar; it's like everyone's posessed!");

        }
    }

    public void Ending4Answer0() //Liam calling Sheriff about bar fight
    {
        Debug.Log("Ending 4, Call 0");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z1": // Sheriff: Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Sheriff, is Liam Brown. I own and run the bar downtown." +
                        " Something has comeover the patrons, they've been fighting.  Physically throwing " +
                        "punches and nothing will make it stop.  My bouncer is overwhelmed.  We need you.");
                    _dialogueChatter.Add("I'm tied up at the moment but I'll send the deputies down there to " +
                        "get a handle on things.");
                    _dialogueChatter.Add("Please hurry. Someone may already be seriously hurt.");
                    _dialogueChatter.Add("Understood.  Over and out.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();

                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending4Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C7") // LUCAS calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, gimme the Sheriff!");

        }
    }
    public void Ending4Answer1() //Lucas talking gibberish to Sheriff
    {
        Debug.Log("Ending 4, Call 1");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z1": //Sheriff: Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Lucas: Sheriff! Sheriff! It's me, Lucas Porter! ");
                    _dialogueChatter.Add("Sheriff Czerniak: Not now Lucas. I don't have have time to be chasing dogs.");
                    _dialogueChatter.Add("Lucas: It's the water.");
                    _dialogueChatter.Add("Sheriff Czerniak: We haven't received the results back yet, but " +
                        "I can guarantee it aint the water that's making you sick.");
                    _dialogueChatter.Add("Lucas: There's bugs in the water. It's making everyone sick. Everyone. Larvae. " +
                        "in the water. We gotta fight them somehow.");
                    _dialogueChatter.Add("Sheriff Czerniak: Lucas, what have you been smoking.");
                    _dialogueChatter.Add("Lucas: Smoke?! Wait... Fire! That's how we fight them.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending4Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z1") // SHERIFF calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator... send me to William Tauten.");

        }
    }
    public void Ending4Answer2() //Sheriff schemes to get Tauten erroneously committed
    {
        Debug.Log("Ending 4, call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z8": //Deputy: William Tauten
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Deputy Tauten: Deputy William Tauten");
                    _dialogueChatter.Add("Sheriff Czerniak: Tauten, it's Czerniak. You're due for an evaluation " +
                        "back at the station. Nothing to worry about. I just had mine done the other day.");
                    _dialogueChatter.Add("Deputy Tauten: What time do I need to be back at the station?");
                    _dialogueChatter.Add("Sheriff Czerniak: The sooner the better.");
                    _dialogueChatter.Add("Deputy Tauten: Alright. I'll head there now. I just finished my rounds.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending4Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Z1") // SHERIFF calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, I need the psych doc. Stat. We have a real loon on our hands.");

        }
    }
    public void Ending4Answer3() //Sheriff wants to commit Lucas Porter for real psychosis
    {
        Debug.Log("Ending 4, call 3");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "X1": // Psyche Doctor: Patrick Walskin
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Sheriff Czerniak: Walskin, it's Sheriff Czerniak.");
                    _dialogueChatter.Add("Patrick: I'm listening.");
                    _dialogueChatter.Add("Sheriff Czerniak: It's Lucas Porter again. This time he was raving " +
                        "on about larvae in the water supply. The last thing he said was that he needed fire " +
                        "to fight them.");
                    _dialogueChatter.Add("Patrick: And if he won't submit to an eval.");
                    _dialogueChatter.Add("Sheriff Czerniak: We won't know until we try. I think we may have " +
                        "actually found a case, haha.");
                    _dialogueChatter.Add("Patrick: It's more common than you think");
                    _dialogueChatter.Add("Sheriff Czerniak: Just head over there and I gotta finish up at the " +
                        "station and then I'll head that way.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending4Call4()
    {
        if (_switchboard2.WhoIsCalling().placementName == "X1") // PATRICK WALKSIN calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, the Sheriff, give me the Sheriff and fast!");

        }
    }
    public void Ending4Answer4() //Porter house on Fire
    {
        Debug.Log("Ending 4, Call 4");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z1": // Sheriff: Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Patrick: Sheriff, the Porter house is on fire!");
                    _dialogueChatter.Add("Sheriff Czerniak: What!?");
                    _dialogueChatter.Add("Patrick: It's on fire. I don't know if anyone is still " +
                        "in the house but it's ablaze!");
                    _dialogueChatter.Add("Sheriff Czerniak: I'm still at the station dealing with the situation. " +
                        "Let me call Amos.");
                    _dialogueChatter.Add("Patrick: Okay.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending4Call5()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C6") // BEATRICE calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, please, I need Tulip Pattinson.");

        }
    }
    public void Ending4Answer5() //Beatrice witnesses kidnapping of Deputy Tauten
    {
        Debug.Log("Ending 4, Call 5");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "C9": // Hairdresser: Tulip Pattinson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Tulip: It's Tulip, honey.");
                    _dialogueChatter.Add("Beatrice: Girl, it's me!");
                    _dialogueChatter.Add("Tulip: What is it, honey?");
                    _dialogueChatter.Add("Beatrice: I just saw them put Deputy Tauten in a straightjacket and" +
                        "haul him away in a van");
                    _dialogueChatter.Add("Tulip: Girl! Something about that don't seem right.");
                    _dialogueChatter.Add("Beatrice: I know.");
                    _dialogueChatter.Add("Tulip:... ");
                    _dialogueChatter.Add("Beatrice:...");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending4Call6()// SHERIFF calling Amos
    {
        
        if (_switchboard2.WhoIsCalling().placementName == "Z1")
        { 
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, send me over to Amos the Warden.");

        }
    }
    public void Ending4Answer6() //Tauten admitted to asylum erroneously
    {
        Debug.Log("Ending 4, Call 6");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "A2": // Warden: Amos Saxton
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Sheriff Czerniak: Amos, it's Sheriff Czerniak. ");
                    _dialogueChatter.Add("Amos: Yes. Sheriff?");
                    _dialogueChatter.Add("Sheriff Czerniak: I sent the Doctor over to the Porter house." +
                        "He said it was on fire.");
                    _dialogueChatter.Add("Amos: Oh, wow.");
                    _dialogueChatter.Add("Sheriff Czerniak: Yeah.  Well, he's already signed the papers so " +
                        "we can move forward.  There will be two coming to you. The other patient " +
                        "put up heavy resistence but in the end, we got him. He will need to be " +
                        "keep sedated and transferred out of state as soon as possible.");
                    _dialogueChatter.Add("Amos: That won't be an issue. I have a van prepped and ready for your " +
                        "arrival.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending4Call7() //Xena, the time is now
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y5") // Xena calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, the time is now.");

        }
    }
    public void Ending4Answer7() // Xena calling and the people go into the mines
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y5") 
        {
            //the people go into the mines 
        }

    }

    //-----------------Ending 1 - Good Ending -------
    public void Ending1Call0()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y9") // THOMAS calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator... We'll be evacuating everyone but we may still need you until the very " +
                "end. But we won't leave without you. Please get me over to the Sheriff.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();

        }
    }
    public void Ending1Answer0() //Thomas Sanford calls Sheriff to the station for country wide evac
    {
        Debug.Log("Ending 1, Call 0");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z1": //Thomas Sanford calls Sheriff Charlie Czerniak
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Thomas: Sheriff! It's Thomas Sanford ");
                    _dialogueChatter.Add("Sheriff Czerniak: Not now Thomas.");
                    _dialogueChatter.Add("Thomas: Yes, now. We need to evacuate this town. It's the water." +
                        "It's the air. Those mines are poisoning everyone who lives here. We've been called to " +
                        " evacuate!");
                    _dialogueChatter.Add("Sheriff Czerniak: We haven't gotten the test results back.");
                    _dialogueChatter.Add("Thomas: I got them today. Along with a letter stating this is an official " +
                        "emergency. We'll have buses before today's end to shuttle people out of the town for medical " +
                        "examination and housing.");
                    _dialogueChatter.Add("Sheriff Czerniak: And what about the Asylum patients?");
                    _dialogueChatter.Add("Thomas: What about them? Everyone is being evacutaed. Everyone. You " +
                        "and Deputy Walskin, meet me at the station. We'll evacuate people by dividing up the town.");
                    _dialogueChatter.Add("Copy that.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending1Call1()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y9") // THOMAS calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, now I need to speak with Deputy William Tauten.");

        }
    }
    public void Ending1Answer1() //Thomas Sanford calls Tauten to aid in evacuation
    {
        Debug.Log("Ending 1, call 1");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "Z8": //Thomas Sanford calls William Tauten
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Deputy Tauten: Deputy William Tauten");
                    _dialogueChatter.Add("Thomas: Tauten, This is Thomas Sanford. We have an county-wide " +
                        "official emergency that requires evacuation.");
                    _dialogueChatter.Add("Deputy Tauten: I'll organize with Deputy Walskin and the Sheriff... ");
                    _dialogueChatter.Add("Thomas: No. In light of your prelimenary investigative work, we're going to " +
                        "handle them a different way.  We are going to need you to step up, okay? You'll need to " +
                        "go door to door warning the citizens about the evacuation. Tell them to take only what " +
                        "they need and that the evacuation buses will arrive at 2pm to shuttle people to safety.");
                    _dialogueChatter.Add("Deputy Tauten: I'll get started.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending1Call2()
    {
        if (_switchboard2.WhoIsCalling().placementName == "C6") // BEATRICE calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator, rush me over to Tulip! ");

        }
    }
    public void Ending1Answer2() //Beatrice witnesses the arrest of Sheriff Czerniak and Walskin
    {
        Debug.Log("Ending 1, Call 2");
        switch (_switchboard2.WhoIsAnswering().placementName)
        {
            case "C9": // Beatrice calls Tulip Pattinson
                {
                    ResetDialogueIteration();
                    _dialogueChatter.Clear();
                    //_dialogueChatter.Add("");
                    _dialogueChatter.Add("Tulip: It's Tulip, honey.");
                    _dialogueChatter.Add("Beatrice: Girl, it's me!");
                    _dialogueChatter.Add("Tulip: What is it, honey?");
                    _dialogueChatter.Add("Beatrice: Deputy Walskin and the Sheriff were " +
                        "just handcuffed and put in a van.");
                    _dialogueChatter.Add("Tulip: Girl! I knew something wasn't right with them.");
                    _dialogueChatter.Add("Beatrice: I gotta call you back. Someone is at the door.");
                    _switchboard2.AdvanceCallCount();
                    _switchboard2.CallIsComplete();
                    break;
                }
            default:
                {
                    Debug.Log("There was no answer.");
                    //No answer
                    break;
                }
        }
    }
    public void Ending1Call3()
    {
        if (_switchboard2.WhoIsCalling().placementName == "Y5") // THOMAS calling
        {
            ResetDialogueIteration();
            _dialogueChatter.Clear();
            //_dialogueChatter.Add("");
            _dialogueChatter.Add("Operator. The time to evacuate is now.");
            //starting ending sequence
        }
    }



    public void ContinueConvoCaller()
    {
        switch (_switchboard2.WhatDayItIs()) // && _switchboard2.CallCount() == 0)
        {
            case 1:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                Day1Answer0();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                Day1Answer1();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                Day1Answer2();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                Day1Answer3();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                Day1Answer4();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                Day1Answer5();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                Day1Answer6();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                Day1Answer7();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                Day2Answer0();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                Day2Answer1();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                Day2Answer2();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                Day2Answer3();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                Day2Answer4();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                Day2Answer5();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                Day2Answer6();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                Day2Answer7();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }
            case 3:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                Day3Answer0();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                Day3Answer1();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                Day3Answer2();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                Day3Answer3();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                Day3Answer4();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                Day3Answer5();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                Day3Answer6();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }
            case 4:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                Day4Answer0();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                Day4Answer1();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                Day4Answer2();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                Day4Answer3();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                Day4Answer4();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                Day4Answer5();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                Day4Answer6();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                Day4Answer7();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }
            case 5:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                Day5Answer0();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                Day5Answer1();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                Day5Answer2();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                Day5Answer3();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                Day5Answer4();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                Day5Answer5();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                Day5Answer6();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                Day5Answer7();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }
            case 6:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                Day6Answer0();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                Day6Answer1();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                Day4Answer2();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                Day6Answer3();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                Day6Answer4();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                Day6Answer5();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                Day6Answer6();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                Day6Answer7();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 8:
                            {
                                Day6Answer8();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }
            case 7:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                Day7Answer0();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                Day7Answer1();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                Day7Answer2();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                Day7Answer3();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                Day7Answer4();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                Day7Answer5();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }
            case 8:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                Day8Answer0();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                Day8Answer1();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                Day8Answer2();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                Day8Answer3();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                Day8Answer4();
                                _dialogueManager.DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }
        }
    }
    public void ClearDialogueScreenButton()
    {
        _callerPanel.SetActive(false);
        _dialogue.text = "";
    }

}

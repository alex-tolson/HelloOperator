using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _dialogue;
    [SerializeField] private GameObject _callerPanel;
    [SerializeField] private GameObject _answererPanel;
    private Switchboard2 _switchboard2;
    //private string _choice;
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

    public void DisplayDialogue()
    {
        _callerPanel.SetActive(true);
        _dialogue.text = _callManager.ReturnDialogueChatter();
    }

    //if it's day one, display dialog for call 0
    public void CycleThroughDialogue()
    {
        switch (_switchboard2.WhatDayItIs())
        {
            case 1:
                {
                    switch (_switchboard2.CallCount())
                    {
                        case 0:
                            {
                                
                                _callManager.Day1Call0();
                                DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                _callManager.Day1Call1();
                                DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                _callManager.Day1Call2();
                                DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                _callManager.Day1Call3();
                                DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                _callManager.Day1Call4();
                                DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                _callManager.Day1Call5();
                                DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                _callManager.Day1Call6();
                                DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                _callManager.Day1Call7();
                                DisplayDialogue();
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

                                _callManager.Day2Call0();
                                DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                _callManager.Day2Call1();
                                DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                _callManager.Day2Call2();
                                DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                _callManager.Day2Call3();
                                DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                _callManager.Day2Call4();
                                DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                _callManager.Day2Call5();
                                DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                _callManager.Day2Call6();
                                DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                _callManager.Day2Call7();
                                DisplayDialogue();
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

                                _callManager.Day3Call0();
                                DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                _callManager.Day3Call1();
                                DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                _callManager.Day3Call2();
                                DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                _callManager.Day3Call3();
                                DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                _callManager.Day3Call4();
                                DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                _callManager.Day3Call5();
                                DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                _callManager.Day3Call6();
                                DisplayDialogue();
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

                                _callManager.Day4Call0();
                                DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                _callManager.Day4Call1();
                                DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                _callManager.Day4Call2();
                                DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                _callManager.Day4Call3();
                                DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                _callManager.Day4Call4();
                                DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                _callManager.Day4Call5();
                                DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                _callManager.Day4Call6();
                                DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                _callManager.Day4Call7();
                                DisplayDialogue();
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
                                _callManager.Day5Call0();
                                DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                _callManager.Day5Call1();
                                DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                _callManager.Day5Call2();
                                DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                _callManager.Day5Call3();
                                DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                _callManager.Day5Call4();
                                DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                _callManager.Day5Call5();
                                DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                _callManager.Day5Call6();
                                DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                _callManager.Day5Call7();
                                DisplayDialogue();
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
                                _callManager.Day6Call0();
                                DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                _callManager.Day6Call1();
                                DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                _callManager.Day6Call2();
                                DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                _callManager.Day6Call3();
                                DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                _callManager.Day6Call4();
                                DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                _callManager.Day6Call5();
                                DisplayDialogue();
                                break;
                            }
                        case 6:
                            {
                                _callManager.Day6Call6();
                                DisplayDialogue();
                                break;
                            }
                        case 7:
                            {
                                _callManager.Day6Call7();
                                DisplayDialogue();
                                break;
                            }
                        case 8:
                            {
                                _callManager.Day6Call8();
                                DisplayDialogue();
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
                                _callManager.Day7Call0();
                                DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                _callManager.Day7Call1();
                                DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                _callManager.Day7Call2();
                                DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                _callManager.Day7Call3();
                                DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                _callManager.Day7Call4();
                                DisplayDialogue();
                                break;
                            }
                        case 5:
                            {
                                _callManager.Day7Call5();
                                DisplayDialogue();
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
                                _callManager.Day8Call0();
                                DisplayDialogue();
                                break;
                            }
                        case 1:
                            {
                                _callManager.Day8Call1();
                                DisplayDialogue();
                                break;
                            }
                        case 2:
                            {
                                _callManager.Day8Call2();
                                DisplayDialogue();
                                break;
                            }
                        case 3:
                            {
                                _callManager.Day8Call3();
                                DisplayDialogue();
                                break;
                            }
                        case 4:
                            {
                                _callManager.Day8Call4();
                                DisplayDialogue();
                                break;
                            }
                    }
                    break;
                }

        }
    }
}

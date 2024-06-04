using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    [SerializeField] private Transform _slotsContainer;
    private JournalSlot[] slots;
    private JournalInv _journal;
    [SerializeField] private GameObject _journalUIObject;
    [SerializeField] private GameObject _tableOfContentsGO;


    private void Start()
    {
        _journal = JournalInv.Instance;
        _journal.onCallerAddedCallback += UpdateUI;     //call update UI method
    }

    public void UpdateUI()
    {
        Debug.Log("Updating Journal UI");
        slots = _slotsContainer.GetComponentsInChildren<JournalSlot>();
        //Debug.Log("slots.Length = " + slots.Length);
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < _journal.callers.Count)              // go through the journal and 
            {
                //Debug.Log("journalUI:: adding callers to journal");
                slots[i].AddCaller(_journal.callers[i]); //add the callers
            }
            else
            {
                //slots[i].ClearSlot();

            }
        }
    }

    public void JournalClicked()
    {
        //Debug.Log("Journal Selected");                             // select journal
        _journalUIObject.SetActive(!_journalUIObject.activeSelf); // sets game object to be
                                                                  // the opposite of its current self
    }

    public void DisplayInfo()
    {
        //remember that list of callers must NOT be empty when testing
        //work on geting the journal to open up to the table of contents right away
        //work on advance and back buttons

    }

    public void ExitJournalClicked()
    {
        //close out journal
        DeactivateJournalPages();
        _tableOfContentsGO.SetActive(false);
        _journalUIObject.SetActive(false);
    }

    public void TableOfContentsClicked()
    {   
        DeactivateJournalPages();            //jump to table of contents
        _tableOfContentsGO.SetActive(true);  //activate the table of contents page.
        Debug.Log("Showing Table of Contents");
    }

    public void DeactivateJournalPages()
    {
        //cycle through all pages
        //setactive to false.
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);
        }
    }
}

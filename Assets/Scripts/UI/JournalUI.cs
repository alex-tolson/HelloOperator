using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    [SerializeField] private Transform _slotsParent;
    private JournalSlot[] slots;
    private JournalInv journal;
    [SerializeField] private GameObject _journalUIObject;


    private void Start()
    {
        journal = JournalInv.Instance;
        //call update UI method
    }
    private void Update()                      
    {
        if (Input.GetButtonDown("Journal"))  // if button pressed or mouse clicked:
        {
            Debug.Log("Opening Journal");    // open journal
            _journalUIObject.SetActive(!_journalUIObject.activeSelf); // sets game object to be
                                                                      // the opposite of its current self
        }
    }

    private void UpdateUI()
    {
        Debug.Log("Updating Journal UI");
        //slots = _slotsParent.GetComponentsInChildren<JournalSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < journal.callers.Count)      // go through the journal and add the callers
            {
                slots[i].AddCaller(journal.callers[i]);
            }
            else
            {
                slots[i].ClearSlot();

            }
        }
    }
}

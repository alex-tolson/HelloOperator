using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPage_Manager : MonoBehaviour
{
    [SerializeField] private Transform _journalPages_container;
    private JournalSlot[] _journalPages;
    private JournalUI _journalUI;

    private void Start()
    {
        _journalUI = GameObject.Find("UIManager").GetComponent<JournalUI>();
        if (_journalUI == null)
        {
            Debug.LogError("JournalPage_Manager::JournalUI is null");
        }
    }

    public void RequestPage()
    {
        _journalUI.ActivateJournalPages();
        _journalPages = _journalPages_container.GetComponentsInChildren<JournalSlot>();
        for (int i = 0; i < _journalPages.Length; i++) //go through all the journal pages
        {
            foreach (JournalSlot page in _journalPages)
            {
                if (i == _journalUI.pageNumber)          //if one matches the correct page number
                {
                    _journalPages[i].gameObject.SetActive(true); //make page active

                }
                else                                    //else
                {
                    _journalPages[i].gameObject.SetActive(false); //make page inactive
                }

            }
           // return _journalPages[i].gameObject;         //return page
        }
        
        //return null;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Requesting Page update");
        //    _journalUI.DeactivateTableOfContents();
        //    _journalUI.ActivateJournalPages();
        //    RequestPage();
        //}
    }

}

using UnityEngine;

public class JournalUI : MonoBehaviour
{
    [SerializeField] private Transform _slotsContainer;
    [SerializeField] private Transform _tocSlotsContainer;
    //[SerializeField] private JournalSlot[] _pages;
    [SerializeField] private JournalSlot[] _slots;
    [SerializeField] private TOCSlot[] _tocSlots;
    
    JournalInv journal;

    [SerializeField] private GameObject _journalUIObject;
    [SerializeField] private GameObject _tableOfContentsGO;
    [SerializeField] private GameObject _indexGO; 
    [SerializeField] private GameObject _advanceGO;
    [SerializeField] private GameObject _goBackGO;
    [SerializeField] private JournalPage_Manager _journalPage_manager;
    public int pageNumber = -1;

    private void OnEnable()
    {
        journal = JournalInv.Instance;

    }

    private void Start()
    {
        journal.onCallerAddedCallback += UpdateUI;     //call update UI method
        _slots = _slotsContainer.GetComponentsInChildren<JournalSlot>();
        if (_slots == null)
        {
            Debug.LogError("JournalUI::StartMethod:: _slots is null");
        }
        _tocSlots = _tocSlotsContainer.GetComponentsInChildren<TOCSlot>();
        if (_tocSlots == null)
        {
            Debug.LogError("JournalUI::StartMethod:: _tocSlots is null");
        }
        UpdateUI();
        DeactivateJournalPages();
        //_tableOfContentsGO.SetActive(true);  //activate the table of contents page.
        DeactivateTableOfContents();
        
    }
    //table of contents or journal slots must be active to populate the array.
    public void UpdateUI()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < journal.callers.Count)              // go through the journal and 
            {
                _slots[i].AddCaller(journal.callers[i]); //add the callers
                _tocSlots[i].AddToTableOfContents(journal.callers[i]);
            }
            else
            {
                _slots[i].ClearSlot();
                _tocSlots[i].ClearTOCSlot();
            }
        }
    }

    public void JournalClicked()
    {
        if (_journalUIObject.activeSelf == false) //if journal is false
        {
            _journalUIObject.SetActive(true); //set turn on journal game object
            DeactivateJournalPages();   //turn off journal pages
            ActivateTableOfContents(); //activate table of contents
        }
        else
        {
            _journalUIObject.SetActive(false); //turn off journal game object
            DeactivateJournalPages();
            DeactivateTableOfContents();
        }
    }

    public void DisplayInfo()
    {
        //remember that list of callers must NOT be empty when testing

        //work on getting the journal to open up to the table of contents right away == DONE
        //--done: provided they are active in the hierarchy

        //work on advance and back buttons

    }

    public void ExitJournalClicked()
    {
        //close out journal
        _journalUIObject.SetActive(false);
        DeactivateJournalPages();
        _tableOfContentsGO.SetActive(false);
    }

    public void TableOfContentsClicked()
    {   
                 
        if (!_tableOfContentsGO.activeInHierarchy) //if table of contents is false
        {
            DeactivateJournalPages();       //deactivate journal pages and
            _tableOfContentsGO.SetActive(true); //show table of contents game object
            ActivateTableOfContents();          //show the table of contents contents
        }
        _goBackGO.SetActive(false);
    }

    public void DeactivateJournalPages() //Sets all pages in the journal to false
    {
        foreach (JournalSlot slot in _slots)
        {       
            slot.gameObject.SetActive(false);
        }
    }

    public void DeactivateTableOfContents()
    {
        foreach (TOCSlot slot in _tocSlots)
        {
            slot.gameObject.SetActive(false);
            //Debug.Log("deactivating: " + slot.name);
        }
    }

    public void AdvanceButtonClicked()
    {
        Debug.Log("advance :: page number is " + pageNumber);
        _goBackGO.SetActive(true);
        pageNumber++;

        if (pageNumber >= 0)
        {
            DeactivateTableOfContents();
        }
        _journalPage_manager.RequestPage();
    }

    public void GoBackButtonClicked()
    {
        Debug.Log("go back :: page number is " + pageNumber);
        pageNumber--;

        if (pageNumber <= -1)
        {
            pageNumber = -1;
            _goBackGO.SetActive(false);
            DeactivateJournalPages();
            ActivateTableOfContents();
        }
        _journalPage_manager.RequestPage();
    }

    public void ActivateTableOfContents()
    {
        foreach (TOCSlot slot in _tocSlots)
        {
            slot.gameObject.SetActive(true);
        }
        Debug.Log("activating: table of contents");
    }

    public void ActivateJournalPages()
    {
        //_slots = _slotsContainer.GetComponentsInChildren<JournalSlot>();
        foreach (JournalSlot slot in _slots)
        {
            slot.gameObject.SetActive(true);
            Debug.Log("activating Journal Page");
        }       
    }
 
}

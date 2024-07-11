using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class JournalPage_Manager : MonoBehaviour
{
    #region Singleton
    private static JournalPage_Manager _instance;

    public static JournalPage_Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("JournalPage_Manager is null");

            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] private Transform _journalPages_container;
    [SerializeField] private JournalSlot[] _journalPages;
    private JournalUI _journalUI;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _journalUI = GameObject.Find("UIManager").GetComponent<JournalUI>();
        if (_journalUI == null)
        {
            Debug.LogError("JournalPage_Manager::JournalUI is null");
        }
    }

    public GameObject RequestPage()
    {
        _journalPages = GetComponentsInChildren<JournalSlot>();
        for (int i = 0; i < _journalPages.Length; i++)
        {
            if (i == _journalUI.pageNumber)
            {
                //return page[i]
            }
        }
        return null;
    }
}

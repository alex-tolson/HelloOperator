using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JournalInv : MonoBehaviour
{
    #region Journal Singleton
    private static JournalInv _instance;
    public static JournalInv Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("JournalInv instance is null");
                _instance = FindObjectOfType(typeof(JournalInv)) as JournalInv;
                Debug.Log("Error resolved");
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _instance = this;
    }
    

    public delegate void onCallerAdded();                       //creates a delegate for onCallerAdded
    public onCallerAdded onCallerAddedCallback;
    public List<Caller> callers = new List<Caller>();           //a list of known callers (entries in the Journal)

    private void Start()
    {
        DefaultJournalEntries();
    }
    public void AddToJournal(Caller newCaller)      //calling this function adds a new caller into the journal.
    {
        if (callers.Count == 0)
        {
            Debug.Log("adding " + newCaller + " to journal called");
            callers.Add(newCaller);                 //add caller to journal 
            if (onCallerAddedCallback != null)      //update UI Journal
            {
                onCallerAddedCallback.Invoke();
            }
        }
        else
        {
            for (int i = 0; i < callers.Count; i++)
            {
                if (callers.Contains(newCaller))
                {
                    Debug.Log("Duplicate entry: " + newCaller);
                    return;                           //return and don't add to journal again.
                }
                else
                {
                    Debug.Log("adding " + newCaller + " to journal called");
                    callers.Add(newCaller);                 //add caller to journal 
                    if (onCallerAddedCallback != null)      //update UI Journal
                    {
                        onCallerAddedCallback.Invoke();
                    }
                }
            }
        }
    }
    private void DefaultJournalEntries()
    {
        for (int i = 0; i < CallerDB.Instance.callerDatabase.Count; i++)
        {
            if (CallerDB.Instance.callerDatabase[i].callerID <= 5)
            {
                AddToJournal(CallerDB.Instance.callerDatabase[i]);
            }
        }
    }
   
}
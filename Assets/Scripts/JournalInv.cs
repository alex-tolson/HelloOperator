using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalInv : MonoBehaviour
{
    #region Singleton
    private static JournalInv _instance;
    public static JournalInv Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("JournalInv instance is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public delegate void onCallerAdded();                       //creates a delegate for onCallerAdded
    public onCallerAdded onCallerAddedCallback;
    public List<Caller> callers = new List<Caller>();           //a list of known callers (entries in the Journal)

    public void AddToJournal(Caller newCallerEntry)             //calling this function adds a new caller into the journal.
    {
        for (int i = 0; i < callers.Count; i++)                 //loop thru the list of callers
        {
            if (callers[i] == newCallerEntry)//caller already exists in journal
            {
                return;     //return and don't add to journal again.
            }
            else            //else
            {
                callers.Add(newCallerEntry);        //add caller to journal 
                if (onCallerAddedCallback != null)      //update UI Journal
                {
                    onCallerAddedCallback.Invoke();
                }
            }
        }
    }
}
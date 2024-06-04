using System.Collections;
using System.Collections.Generic;
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



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            foreach (Caller caller in CallerDB.Instance.callerDatabase)
            {
                Debug.Log("0 key was pressed");

                if (caller.callerID == 0)
                {
                    AddToJournal(caller);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Caller caller in CallerDB.Instance.callerDatabase)
            {

                if (caller.callerID == 1)
                {
                    AddToJournal(caller);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Caller caller in CallerDB.Instance.callerDatabase)
            {

                if (caller.callerID == 2)
                {
                    AddToJournal(caller);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (Caller caller in CallerDB.Instance.callerDatabase)
            {

                if (caller.callerID == 3)
                {
                    AddToJournal(caller);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (Caller caller in CallerDB.Instance.callerDatabase)
            {

                if (caller.callerID == 4)
                {
                    AddToJournal(caller);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            foreach (Caller caller in CallerDB.Instance.callerDatabase)
            {
                if (caller.callerID == 5)
                {
                    AddToJournal(caller);
                }

            }

        }

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
}
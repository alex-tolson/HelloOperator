using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallerDB : MonoBehaviour
{
    #region Database Singleton
    private static CallerDB _instance;

    public static CallerDB Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("CallerDB is null");
            }
            return _instance;
        }
    }

    #endregion

    private void Awake()
    {
        _instance = this;
    }

   // public Caller caller;
    public List<Caller> callerDatabase = new List<Caller>();



}

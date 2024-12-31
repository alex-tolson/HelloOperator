using System.Collections.Generic;
using UnityEngine;

public class SwitchboardDB : MonoBehaviour
{

    #region Database Singleton
    private static SwitchboardDB _instance;

    public static SwitchboardDB Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SwitchboardDB is null");
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
    public List<SwitchboardSO> switchboardSODatabase = new List<SwitchboardSO>();


}

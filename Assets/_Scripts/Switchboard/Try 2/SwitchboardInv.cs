using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchboardInv : MonoBehaviour
{
    #region SwitchboardInv Singleton
    private static SwitchboardInv _instance;

    public static SwitchboardInv Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SwitchboardInv is null");
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        AddToSwitchboard();
    }

    public List<SwitchboardSO> _switchboardList = new List<SwitchboardSO>();

    //add all the entries in the database in the _switchboard

    private void AddToSwitchboard()
    {
        for (int i = 0; i < SwitchboardDB.Instance.switchboardSODatabase.Count; i++)//loop through the database
        {
            _switchboardList.Add(SwitchboardDB.Instance.switchboardSODatabase[i]);
        }
    }

    //public float FindNearestPlaceHolder(Vector3 position)
    //{
    //    var distance = Vector3.Distance(transform.position, position);
    //    return distance;
    //}
}

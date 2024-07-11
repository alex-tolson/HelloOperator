using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TOCSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;

    public void AddToTableOfContents(Caller caller)
    {
        _name.text = caller.callerName;
    }
    public void ClearTOCSlot()
    {
        _name.text = "";
    }
}

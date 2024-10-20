using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TOCSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;

    public void AddToTableOfContents(Caller caller)
    {
        //Debug.Log("adding name to table of contents");
        _name.text = caller.cName;
    }
    public void ClearTOCSlot()
    {
        _name.text = "";
    }
}

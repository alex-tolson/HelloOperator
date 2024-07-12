using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCaller", menuName = "Caller/Create newCaller")]
public class Caller : ScriptableObject
{
    public int callerID;
    public string cName;
    public string callerOccupation;
    public string callerLocation;
    public Sprite callerIcon;
    public string description;
    public GameObject callerActiveLight;
    public GameObject callerSwitchState;
    public SpriteRenderer incomingCallerPlug;
    public SpriteRenderer outgoingCalleePlug;

}

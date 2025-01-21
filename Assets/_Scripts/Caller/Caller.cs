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
    public string hairColor;
    public string eyeColor;
    public bool faceHair;
    public bool maleSex;
    public bool tattoo;
    public bool piercings;


}

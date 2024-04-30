using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Actor", menuName = "Actor/Create New Actor")]
public class Actor : ScriptableObject
{
    public int actorID;
    public string actorName;
    public string actorOccupation;
    public string actorLocation;
    public Sprite icon;

}

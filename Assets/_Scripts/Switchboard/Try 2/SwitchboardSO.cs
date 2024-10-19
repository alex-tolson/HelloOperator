using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlacement", menuName = "Switchboard/Create Placement")]
public class SwitchboardSO : ScriptableObject
{
    public string placementName;
    //public IncomingJack incomingLocation;
    //public AnchorPlaceHolder outgoingLocation;
    public Switch placementSwitch;
    public JackDirection jackDirection;
    public CurrentState currentState;
    public Vector3 _vector3Location;
    public SpriteRenderer light;
}

public enum CurrentState
{
    Idle,
    Ringing,
    Answered,
    Connected
}
public enum JackDirection
{
    Incoming,
    Outgoing
}
public enum Switch
{ 
    ToggleDown,
    ToggleUp,
}

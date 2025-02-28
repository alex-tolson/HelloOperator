using UnityEngine;

[CreateAssetMenu(fileName = "NewPlacement", menuName = "Switchboard/Create Placement")]
public class SwitchboardSO : ScriptableObject
{
    public string placementName;
    public Switch placementSwitch;
    public JackDirection jackDirection;
    public CurrentState currentState;
    public Vector3 _vector3Location;
}

public enum CurrentState
{
    Idle,
    OnCall
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

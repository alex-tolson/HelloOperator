using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchboard : MonoBehaviour
{
    //when bell is hit
    //a call comes through --- need a list of all available callers
    //player clicks on lit up area
    //a wire connects lit up area to the switchboard
    //player hits switch up to hear caller
    //Player selects where to place the call
    //player hits switch down to connect the call
    //both lights turn green as they are connected
    //when both lights turn off, the call has ended.
    //player turns switch off.

    //--------------------------------
    [SerializeField] private GameObject _bell;
    //[SerializeField] private List<Caller> _callers = new List<Caller>();

    [SerializeField] private bool _callInitialize = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider.name == _bell.name)
            {
                Debug.Log("Player clicked " + hit.collider.name);
                Call_Zero();
            }
            else { return; }
           
        }
    }

   


    private void Call_Zero()
    {
        //caller game objects need colliders to hit...
        _callInitialize = true;
        Debug.Log("Call initializing");
        //caller section light turns on
        //call function to create caller
        //CreateCaller(_callers[0]);
    }

}

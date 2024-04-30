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

    [SerializeField] private GameObject _bell;
    [SerializeField] private List<GameObject> _callers = new List<GameObject>();

    // Start is called before the first frame update


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
                //initiate call
            }
        }
    }

    private void Call_1()
    {
        Debug.Log("Call 1 initiated.");
        int random_Call_1 = Random.Range(0, _callers.Count + 1);
        //cycle through list of callers
        //if random_call_1 matches caller
        //start that dialog.
        //need a caller script.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPlaceHolder : MonoBehaviour
{
    public float FindNearestPlaceHolder(Vector3 position)
    {
        var distance = Vector3.Distance(transform.position, position);
        return distance;
    }
}

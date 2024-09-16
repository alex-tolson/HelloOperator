using UnityEngine;

public class Jack : MonoBehaviour
{
    public float FindNearestJack(Vector3 position)
    {
        var distance = Vector3.Distance(transform.position,position);
        return distance;
    }
    
    




}

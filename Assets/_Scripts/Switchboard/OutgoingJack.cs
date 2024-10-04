using UnityEngine;

public class OutgoingJack : MonoBehaviour
{
    public float FindNearestOutgoingJack(Vector3 position)
    {
        var distance = Vector3.Distance(transform.position,position);
        return distance;
    }
}

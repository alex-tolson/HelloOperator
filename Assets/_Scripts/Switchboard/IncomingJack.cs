using UnityEngine;

public class IncomingJack : MonoBehaviour
{
    public float FindNearestIncomingJack(Vector3 position)
    {
        var distance = Vector3.Distance(transform.position,position);
        return distance;
    }
}

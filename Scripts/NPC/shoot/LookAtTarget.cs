using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}

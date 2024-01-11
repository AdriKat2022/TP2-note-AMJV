using UnityEngine;

public class ForceField : MonoBehaviour
{
    [SerializeField]
    private float repulsiveForce;


    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out IPushable pushable))
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.y = 0;
            pushable.Push(direction * repulsiveForce);
        }
    }
}

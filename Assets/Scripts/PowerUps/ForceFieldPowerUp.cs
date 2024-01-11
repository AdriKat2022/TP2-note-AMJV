using UnityEngine;

public class ForceFieldPowerUp : MonoBehaviour
{
    [SerializeField]
    private float duration;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PowerUpsApplication player))
        {
            player.ActivateForceFieldFor(duration);
            Destroy(gameObject);
        }
    }
}

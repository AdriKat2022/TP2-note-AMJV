using UnityEngine;
using UnityEngine.AI;

public class PoliceBehaviour : MonoBehaviour, IPushable
{
    [SerializeField] private NavMeshAgent police;
    private GameObject target;

    private ParticleSystem ps;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        ps = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        police.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            ps.transform.parent = null;
            ps.Play();
            Destroy(this.gameObject);
        }
    }

    public void Push(Vector3 force)
    {
        rb.AddForce(force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent police;
    private GameObject target;

    private ParticleSystem ps;

    private void Start()
    {
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
}

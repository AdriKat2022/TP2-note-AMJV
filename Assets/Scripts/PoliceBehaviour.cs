using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent police;
    [SerializeField] private Transform target;

    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        police.SetDestination(target.position);       
    }

    private void OnCollisionEnter(Collision collision)
    {
        ps.transform.parent = null;
        ps.Play();
        Destroy(this.gameObject); 
    }
}

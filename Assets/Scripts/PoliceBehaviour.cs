using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent police;
    [SerializeField] private Transform target;

    void Update()
    {
            police.SetDestination(target.position);       
    }
}

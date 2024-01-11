using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    public GameObject police;
    private bool waiting;

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            StartCoroutine(SpawnPolice());
        }
    }

    private IEnumerator SpawnPolice()
    {
        waiting = true;
        Instantiate(police);
        yield return new WaitForSeconds(2);
        waiting = false;
    }
}

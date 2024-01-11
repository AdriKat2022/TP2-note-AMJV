using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsApplication : MonoBehaviour
{
    [SerializeField]
    private GameObject forceField;

    public void ActivateForceFieldFor(float duration)
    {
        StartCoroutine(ForceFieldFor(duration));
    }

    private IEnumerator ForceFieldFor(float duration)
    {
        float timer = duration;

        forceField.SetActive(true);

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        forceField.SetActive(false);
    }
}

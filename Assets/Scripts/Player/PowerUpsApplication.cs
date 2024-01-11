using System.Collections;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class PowerUpsApplication : MonoBehaviour
{
    [SerializeField]
    private GameObject forceField;

    private Animator forceFieldAnimator;
    private float timer;
    private bool isActive;

    private void Start()
    {
        isActive = false;
        timer = 0;
        forceField.TryGetComponent(out forceFieldAnimator);
    }


    public void ActivateForceFieldFor(float duration)
    {
        StartCoroutine(ForceFieldFor(duration));
    }
    private IEnumerator ForceFieldFor(float duration)
    {
        timer = duration;
        
        if(isActive)
            yield break;

        isActive = true;

        forceField.SetActive(true);
        forceFieldAnimator.SetTrigger("Reset");

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            forceFieldAnimator.SetFloat("timer", timer);

            yield return null;
        }
        
        isActive = false;
        forceField.SetActive(false);
    }
}

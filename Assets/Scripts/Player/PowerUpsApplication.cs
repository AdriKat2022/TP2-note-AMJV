using System.Collections;
using UnityEngine;

public class PowerUpsApplication : MonoBehaviour
{
    [SerializeField]
    private GameObject forceField;

    private Animator forceFieldAnimator;

    private void Start()
    {
        forceField.SetActive(false);
        forceField.TryGetComponent(out forceFieldAnimator);
    }


    public void ActivateForceFieldFor(float duration)
    {
        StartCoroutine(ForceFieldFor(duration));
    }
    private IEnumerator ForceFieldFor(float duration)
    {
        float timer = duration;

        forceField.SetActive(true);
        forceFieldAnimator.SetTrigger("Reset");

        bool animated = false;

        while (timer > 0)
        {
            timer -= Time.deltaTime;


            if(timer <= 0.8 && !animated)
            {
                animated = true;
                forceFieldAnimator.SetTrigger("End");
            }

            yield return null;
        }
        forceField.SetActive(false);
    }
}

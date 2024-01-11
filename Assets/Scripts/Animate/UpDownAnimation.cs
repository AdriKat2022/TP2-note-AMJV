using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownAnimation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float translationSpeed;
    [SerializeField]
    private float translationDepth;


    private bool isAnimating;

    private Vector3 basePosition;

    private void Start()
    {
        isAnimating = false;
        basePosition = transform.position;
        ToogleAnimation(true);
    }

    public void Reset()
    {
        transform.position = basePosition;
    }

    public void ToogleAnimation(bool animate)
    {
        if (!isAnimating && animate)
            StartCoroutine(Animate());

        isAnimating = animate;
    }

    private IEnumerator Animate()
    {
        float _time = 0;

        while (isAnimating)
        {
            _time += Time.deltaTime;

            float offsetY = Mathf.Sin(_time * translationSpeed * Time.deltaTime) * translationDepth;

            transform.position = basePosition + offsetY * Vector3.up;
            transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.up);

            yield return null;
        }
    }
}

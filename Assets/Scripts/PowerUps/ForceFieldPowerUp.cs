using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldPowerUp : MonoBehaviour, ICollectable
{
    [SerializeField]
    private float duration;

    public void Collect()
    {
        Destroy(gameObject);
    }
}

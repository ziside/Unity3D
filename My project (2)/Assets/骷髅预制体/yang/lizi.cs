using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lizi : MonoBehaviour
{
    new public ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!particleSystem.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
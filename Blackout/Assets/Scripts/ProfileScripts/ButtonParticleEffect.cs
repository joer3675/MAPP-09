using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonParticleEffect : MonoBehaviour
{
    public GameObject particleEffect;

    public void playEffect()
    {
        Instantiate(particleEffect, transform.position, transform.rotation);

        Destroy(gameObject);

    }
}

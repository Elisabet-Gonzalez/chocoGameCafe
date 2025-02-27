using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public ParticleSystem particle;
    private Vector3 lastPosition;
    private float shakeVel;

    private void Start()
    {
        lastPosition = transform.position;
        particle.Stop();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, lastPosition) > shakeVel)
        {
            particle.Play();
            particle.Emit(10);
            StartCoroutine(DisableParticles(1f));
        }

        lastPosition = transform.position;
    }


    private IEnumerator DisableParticles (float delay)
    {
        yield return new WaitForSeconds(delay);
        particle.Stop();
    }


}

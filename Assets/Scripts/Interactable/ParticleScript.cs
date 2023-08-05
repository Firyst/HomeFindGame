using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem Particle;

    void Start()
    {
        Particle.Stop();
    }

    public void SwitchState()
    {
        if (Particle.isPlaying) Particle.Stop();
        else Particle.Play();
    }
}

using UnityEngine;
using System.Collections;

public class Balancer : MonoBehaviour
{
    public float streamLife = 7f;
    public float streamRate = 100f;

    public static void setUpParticleSystem(ParticleSystem emiterParticle)
    {
        Balancer balancer = GameObject.FindGameObjectWithTag("BALANCER").GetComponent<Balancer>();
        emiterParticle.emissionRate = balancer.streamRate;
        emiterParticle.startLifetime = balancer.streamLife;
    }
}

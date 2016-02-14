using UnityEngine;
using System.Collections;

public class SigillEmit : MonoBehaviour
{
    public GameObject emiter;

    //private SigilSpawning sigilSpawning;
    private Animator animator;
    private ParticleSystem emiterParticle;
    private bool wasHit = false;

    void Awake()
    {
        //sigilSpawning = GameObject.FindGameObjectWithTag("Player").GetComponent<SigilSpawning>();
        animator = GetComponent<Animator>();
        emiterParticle = emiter.GetComponent<ParticleSystem>();
        Balancer.setUpParticleSystem(emiterParticle);
    }

    void LateUpdate()
    {
        emiterParticle.enableEmission = wasHit && animator.GetBool("glow");
        wasHit = false;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "LinkStream" || other.tag == "AbsorbStream")
        {
            wasHit = true;
        }
    }
}

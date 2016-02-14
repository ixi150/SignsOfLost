using UnityEngine;
using System.Collections;

public class SigillLink : MonoBehaviour
{
    public GameObject emiter;

    private Animator animator;
    private SigilSpawning sigilSpawning;
    private ParticleSystem emiterParticle;
    private bool wasHit = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        sigilSpawning = GameObject.FindGameObjectWithTag("Player").GetComponent<SigilSpawning>();
        emiterParticle = emiter.GetComponent<ParticleSystem>();
        Balancer.setUpParticleSystem(emiterParticle);
    }

    void LateUpdate()
    {
        bool shouldEmit = sigilSpawning.sigills[1] != null && animator.GetBool("glow") && wasHit;
        if (shouldEmit)
            emiter.transform.LookAt(sigilSpawning.sigills[1].transform);

        emiterParticle.enableEmission = shouldEmit;

        wasHit = false;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "AbsorbStream")
        {
            wasHit = true;
        }
    }
}
